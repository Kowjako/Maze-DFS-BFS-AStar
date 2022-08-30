using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Maze_DFS_BFS.Models
{
    //-----------------------------------------------------------------------
    //
    //  Microsoft Windows Client Platform
    //  Copyright (C) Microsoft Corporation. All rights reserved.
    //
    //  File:      PriorityQueue.cs
    //
    //  Contents:  Implementation of PriorityQueue class.
    //
    //  Created:   2-14-2005 Niklas Borson (niklasb)
    //
    //------------------------------------------------------------------------

    internal class PriorityQueue<T>
    {
        private T[] _heap;
        private int _count;
        private IComparer<T> _comparer;
        private bool _isHeap;
        private const int DefaultCapacity = 6;

        #region Constructor

        internal PriorityQueue(int capacity, IComparer<T> comparer)
        {
            _heap = new T[capacity > 0 ? capacity : DefaultCapacity];
            _count = 0;
            _comparer = comparer;
        }

        #endregion

        #region internal members

        internal int Count
        {
            get { return _count; }
        }

        internal T Top
        {
            get
            {
                Debug.Assert(_count > 0);
                if (!_isHeap)
                {
                    Heapify();
                }

                return _heap[0];
            }
        }

        internal void Push(T value)
        {
            if (_count == _heap.Length)
            {
                Array.Resize<T>(ref _heap, _count * 2);
            }

            if (_isHeap)
            {
                SiftUp(_count, ref value, 0);
            }
            else
            {
                _heap[_count] = value;
            }

            _count++;
        }

        internal void Pop()
        {
            Debug.Assert(_count != 0);
            if (!_isHeap)
            {
                Heapify();
            }

            if (_count > 0)
            {
                --_count;
                T x = _heap[_count];       
                int index = SiftDown(0);    
                SiftUp(index, ref x, 0);    
                _heap[_count] = default(T); 
            }
        }

        #endregion

        #region private members

        private int SiftDown(int index)
        {
            int parent = index;
            int leftChild = HeapLeftChild(parent);

            while (leftChild < _count)
            {
                int rightChild = HeapRightFromLeft(leftChild);
                int bestChild =
                    (rightChild < _count && _comparer.Compare(_heap[rightChild], _heap[leftChild]) < 0) ?
                    rightChild : leftChild;

                _heap[parent] = _heap[bestChild];

                parent = bestChild;
                leftChild = HeapLeftChild(parent);
            }

            return parent;
        }

        private void SiftUp(int index, ref T x, int boundary)
        {
            while (index > boundary)
            {
                int parent = HeapParent(index);
                if (_comparer.Compare(_heap[parent], x) > 0)
                {
                    _heap[index] = _heap[parent];
                    index = parent;
                }
                else
                {
                    break;
                }
            }
            _heap[index] = x;
        }

        private void Heapify()
        {
            if (!_isHeap)
            {
                for (int i = _count / 2 - 1; i >= 0; --i)
                {
                    T x = _heap[i];
                    int index = SiftDown(i);
                    SiftUp(index, ref x, i);
                }
                _isHeap = true;
            }
        }

        public bool Conatins(T item, IEqualityComparer<T> comparer)
        {
            for (int i = 0; i < _heap.Length; i++)
            {
                if (_heap[i] != null && comparer.Equals(item, _heap[i])) return true;
            }
            return false;
        }

        private static int HeapParent(int i) => (i - 1) / 2;
        private static int HeapLeftChild(int i) => (i * 2) + 1;
        private static int HeapRightFromLeft(int i) => i + 1;

        #endregion
    }
}
