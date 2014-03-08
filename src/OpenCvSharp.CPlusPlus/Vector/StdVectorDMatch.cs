﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    internal class StdVectorDMatch : DisposableCvObject, IStdVector
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
        /// <summary>
        /// 
        /// </summary>
        public StdVectorDMatch()
        {
            ptr = CppInvoke.vector_DMatch_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public StdVectorDMatch(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public StdVectorDMatch(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = CppInvoke.vector_DMatch_new2(new IntPtr(size));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StdVectorDMatch(IEnumerable<DMatch> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            DMatch[] array = EnumerableEx.ToArray(data);
            ptr = CppInvoke.vector_DMatch_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (IsEnabledDispose)
                    {
                        CppInvoke.vector_DMatch_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return CppInvoke.vector_DMatch_getSize(ptr).ToInt32(); }
        }
        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return CppInvoke.vector_DMatch_getPointer(ptr); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public DMatch[] ToArray()
        {            
            int size = Size;
            if (size == 0)
            {
                return new DMatch[0];
            }
            DMatch[] dst = new DMatch[size];
            using (ArrayAddress1<DMatch> dstPtr = new ArrayAddress1<DMatch>(dst))
            {
                Util.CopyMemory(dstPtr, ElemPtr, Marshal.SizeOf(typeof(DMatch)) * dst.Length);
            }
            return dst;
        }
        #endregion
    }
}
