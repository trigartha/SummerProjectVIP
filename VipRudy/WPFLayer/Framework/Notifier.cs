﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace WPFLayer.Framework
{
    /// <summary>
    /// Provides a method for Notification support.
    /// We use this class for model classes.
    /// It should be serializable. -->TODO look up why
    /// </summary>
    [Serializable]
    public class Notifier : INotifyPropertyChanged
    {
        #region Properties

        #endregion
        #region Fields
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Constructor

        #endregion
        #region Methods


        /// <summary>
        /// Notifies that <see cref="propertyName" /> has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName)
                    );
            }
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpr = propertyExpression.Body as MemberExpression;
            if (memberExpr == null)
                throw new ArgumentException("Property Expression should represent access to a member");
            string memberName = memberExpr.Member.Name;
            RaisePropertyChanged(memberName);
        }
        #endregion
    }
}
