﻿using System;
using System.Collections;
using System.Linq;
using Object = UnityEngine.Object;


namespace RollABall
{
    public sealed class ListInteractableObject : IEnumerator, IEnumerable
    {
        #region Fields

        private InteractiveObject[] _interactiveObjects;
        private InteractiveObject _current;

        private int _index = -1;

        #endregion


        #region Methods

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
            Array.Sort(_interactiveObjects);
        }

        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }

        public int Count => _interactiveObjects.Length;

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            _current = _interactiveObjects[_index];
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _current;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Remove(InteractiveObject value)
        {
            _interactiveObjects = _interactiveObjects.Except(new InteractiveObject[] { value }).ToArray();
        }

        #endregion
    }
}