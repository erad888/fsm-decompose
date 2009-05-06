using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    /// <summary>
    /// Состояния объекта
    /// </summary>
    public enum PersistentState : int
    {
        /// <summary>
        /// Создан
        /// </summary>
        Created,
        /// <summary>
        /// Актуален
        /// </summary>
        Normal,
        /// <summary>
        /// Модифицирован
        /// </summary>
        Modified,
        /// <summary>
        /// Удалён с клиента
        /// </summary>
        Deleted,
        /// <summary>
        /// Ошибочное состояние
        /// </summary>
        Error,
        /// <summary>
        /// Не существует
        /// </summary>
        NotExists
    }
    /// <summary>
    /// Действия для КА
    /// </summary>
    public enum PersistentAction : int
    {
        /// <summary>
        /// Сохранение
        /// </summary>
        Save,
        /// <summary>
        /// Модификация
        /// </summary>
        Modify,
        /// <summary>
        /// Удаление (на уровне клиента)
        /// </summary>
        Delete,
        /// <summary>
        /// Совершение ошибки
        /// </summary>
        DoError,
        /// <summary>
        /// Исправление ошибки
        /// </summary>
        FixError,
        /// <summary>
        /// Восстановление (на уровне клиента)
        /// </summary>
        Restore,
        /// <summary>
        /// Удаление (из хранилища)
        /// </summary>
        FullDelete,
        /// <summary>
        /// Отмена изменений (на уровне клиента)
        /// </summary>
        Rollback
    }


    ///// <summary>
    ///// Полный КА для среднестатистического объекта
    ///// </summary>
    //public class FullFiniteStateMachine : FiniteStateMachine<PersistentState>
    //{
    //    public FullFiniteStateMachine(PersistentState initialState)
    //    {
    //        FSMState create = new FSMState(this, PersistentState.Created);
    //        FSMState normal = new FSMState(this, PersistentState.Normal);
    //        FSMState modified = new FSMState(this, PersistentState.Modified);
    //        FSMState error = new FSMState(this, PersistentState.Error);
    //        FSMState deleted = new FSMState(this, PersistentState.Deleted);
    //        FSMState notExists = new FSMState(this, PersistentState.NotExists);

    //        // Список допустимых начальных состояний
    //        List<FSMState> AcceptabilityInitialStates = new List<FSMState>();
    //        AcceptabilityInitialStates.Add(create);
    //        AcceptabilityInitialStates.Add(normal);
    //        AcceptabilityInitialStates.Add(error);

    //        create.AddOutgoing(PersistentAction.Save, normal);
    //        create.AddOutgoing(PersistentAction.Delete, notExists);
    //        create.AddOutgoing(PersistentAction.Modify, create);
    //        normal.AddOutgoing(PersistentAction.Save, normal);
    //        normal.AddOutgoing(PersistentAction.DoError, error);
    //        normal.AddOutgoing(PersistentAction.Delete, deleted);
    //        normal.AddOutgoing(PersistentAction.Modify, modified);
    //        error.AddOutgoing(PersistentAction.FullDelete, notExists);
    //        error.AddOutgoing(PersistentAction.FixError, normal);
    //        deleted.AddOutgoing(PersistentAction.Restore, normal);
    //        deleted.AddOutgoing(PersistentAction.FullDelete, notExists);
    //        modified.AddOutgoing(PersistentAction.Modify, modified);
    //        modified.AddOutgoing(PersistentAction.Save, normal);
    //        modified.AddOutgoing(PersistentAction.Rollback, normal);

    //        foreach (var state in AcceptabilityInitialStates)
    //        {
    //            if (state.StateCore == initialState)
    //            {
    //                InitialState = state;
    //                break;
    //            }
    //        }
    //        if (InitialState == null)
    //            throw new NonAcceptableInitialStateException(initialState);
    //    }
    //}



}
