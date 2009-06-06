using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FSM.Representation
{
    public class FSMDataTableRepresenter
    {
        #region static

        public static DataTable Convert<TInput, TOutput>(Transition<TInput, TOutput> transition)
            where TInput : FSMAtomBase, IStringKeyable
            where TOutput : FSMAtomBase, IStringKeyable
        {
            if (transition == null) throw new ArgumentNullException("transition");
            DataTable result = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "Output";
            dc.Caption = "Выходной символ";
            dc.DataType = typeof (TOutput);
            result.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "DestinationState";
            dc.Caption = "Результирующее состояние";
            dc.DataType = typeof (FSMState<TInput, TOutput>);
            result.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Probability";
            dc.Caption = "Вероятность";
            dc.DataType = typeof (double);
            result.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Key";
            dc.DataType = typeof(string);
            result.Columns.Add(dc);

            foreach (var destinationState in transition.destinationStates)
            {
                DataRow row = result.NewRow();

                row[0] = destinationState.Output;
                row[1] = destinationState.DestState;
                row[2] = destinationState.Probability;
                row[3] = destinationState.KeyName;

                result.Rows.Add(row);
            }

            result.Rows.Add(result.NewRow());

            return result;
        }

        public static DataTable Convert<TInput, TOutput>(FiniteStateMachine<TInput, TOutput> fsm)
            where TInput : FSMAtomBase, IStringKeyable
            where TOutput : FSMAtomBase, IStringKeyable
        {
            if (fsm == null) throw new ArgumentNullException("fsm");

            DataTable result = new DataTable();

            result.Columns.Add("Zs");
            foreach (var state in fsm.StateSet)
            {
                DataColumn dc = new DataColumn(state.KeyName);
                dc.DataType = typeof(TransitionRes<TInput, TOutput>);
                //dc.DataType = fsm.
                result.Columns.Add(dc);
            }

            foreach (var input in fsm.InputSet)
            {
                var ienum = fsm.Transitions.Where(tr => tr.Value.Input == input);
                int maxRows = 0;
                if (ienum.Count() > 0)
                {
                    maxRows = ienum.Max(tr => tr.Value.destinationStates.Count);
                }
                else
                    maxRows = 1;
                DataRow[] drs = new DataRow[maxRows];

                //drs[0] = result.NewRow();
                //drs[0]["Zs"] = input;
                for (int i = 0; i < drs.Count(); ++i)
                {
                    drs[i] = result.NewRow();
                    drs[i]["Zs"] = input;
                }

                foreach (var state in fsm.StateSet)
                {
                    Transition<TInput, TOutput> tr = new Transition<TInput, TOutput>(null)
                                                         {
                                                             SourceState = state,
                                                             Input = input
                                                         };


                    var trans = fsm.Transitions.Values.FirstOrDefault(t => t.ToString() == tr.ToString());
                    if (trans != null)
                    {
                        for (int i = 0; i < trans.destinationStates.Count; ++i)
                        {
                            if (drs[i] == null)
                                drs[i] = result.NewRow();
                            drs[i][state.KeyName] = trans.destinationStates[i] as TransitionRes<TInput, TOutput>;
                        }
                    }
                }

                foreach (var dr in drs)
                {
                    result.Rows.Add(dr);
                }
            }

            return result;
        }

        #endregion

        #region Constructors



        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods

        #endregion
    }
}