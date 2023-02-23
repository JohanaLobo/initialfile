using System;

class TQueue<T> {
    public void Enqueue ( T a ) {

        if ( mUsed == mData.Length ) {
            var tmp = new T[mUsed * 2];
            for ( int i = 0; i < mUsed; i++ ) tmp[i] = mData[i];
            mData = tmp;
        }
        mData[mUsed++] = a;
    }

    public T Dequeue () {
        if ( mUsed == 0 ) throw new Exception("Queue is empty");
        T r = mData [start++];
        return r;
    }

    public void Print () {
        for ( int i = start; i < mUsed; i++ ) {
            Console.Write($"{mData[i]} ");
        }
    }
    public bool IsEmpty => mUsed == 0;

    T[] mData = new T[4];
    int mUsed;
    int start;

}
   class Program {
      static void Main ( string[] args ) {
        TQueue <int> que = new ();
        que.Enqueue ( 11 );
        que.Enqueue ( 12 );
        que.Enqueue ( 13 );
        Console.WriteLine ("The queue elements are : ");
        que.Print ();
        que.Dequeue ();
        Console.WriteLine ("\nThe queue after removing the first element: ");
        que.Print();
        Console.WriteLine ("\nThe queue after removing the two elements");
        que.Dequeue();
        que.Dequeue ();
        que.Print ();
      }
}
