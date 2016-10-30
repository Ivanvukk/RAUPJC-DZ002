using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGenericList<T> : IEnumerable<T>
{
    /// <summary>
    /// Adds an item to the collection.
    /// </summary>
    void Add(T item);

    /// <summary>
    /// Removes the first occurrence of an item from the collection.
    /// If the item was not found, method does nothing.
    /// </summary>
    bool Remove(T item);

    /// <summary>
    /// Removes the item at the given index in the collection.
    /// </summary>
    bool RemoveAt(int index);

    /// <summary>
    /// Returns the item at the given index in the collection.
    /// </summary>
    T GetElement(int index);

    /// <summary>
    /// Returns the index of the item in the collection.
    /// If item is not found in the collection, method returns -1.
    /// </summary>
    int IndexOf(T item);

    /// <summary>
    /// Readonly property. Gets the number of items contained in the collection.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Removes all items from the collection.
    /// </summary>
    void Clear();

    /// <summary>
    /// Determines whether the collection contains a specific value.
    /// </summary>
    bool Contains(T item);
}

public class GenericList<T> : IGenericList<T>
{
    private T[] _internalStorage;
    private T[] _backupStorage;
    private int _numberOfElements;
    private int _arraySize;
    private int _idx;

    public GenericList()
    {
        _internalStorage = new T[4];
        _arraySize = 4;
        _numberOfElements = 0;
    }

    public GenericList(int initialSize) //constructor
    {
        if (initialSize < 1)
        {
            throw new ArgumentException("Number of elements must be >0");
        }
        _internalStorage = new T[initialSize];
        _arraySize = initialSize;
        _numberOfElements = 0;
    }

    public int Count
    {
        get
        {
            return _numberOfElements;
        }
    }

    public void Add(T item)
    {
        if (_numberOfElements == _arraySize)                          //Check if there is enough space
        {
            _backupStorage = new T[_numberOfElements];
            for (_idx = 0; _idx < _numberOfElements; _idx++)            //Backup elements 
            {
                _backupStorage[_idx] = _internalStorage[_idx];
            }
            _internalStorage = new T[_numberOfElements * 2];         //Recreate new array
            for (_idx = 0; _idx < _numberOfElements; _idx++)
            {
                _internalStorage[_idx] = _backupStorage[_idx];        //Copy elements from backup
            }
            _arraySize = _numberOfElements * 2;
        }

        _internalStorage[_numberOfElements] = item;                  //Add new element
        _numberOfElements++;
    }

    public void Clear()
    {
        for (_idx = 0; _idx < _numberOfElements; _idx++)
        {
            _internalStorage[_idx] = default(T);
        }
        _numberOfElements = 0;
    }

    public bool Contains(T item)
    {
        if (IndexOf(item) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public T GetElement(int index)
    {
        if (index >= 0 && index < _numberOfElements)
        {
            return _internalStorage[index];                         //Address element 
        }
        else
        {
            throw new ArgumentException("Unacceptable index");          // Throw exceptioon if index is out of range
        }
    }

    public int IndexOf(T item)
    {
        _idx = 0;

        while ((!EqualityComparer<T>.Default.Equals(item, _internalStorage[_idx])) && (_idx < _numberOfElements))
        {
            _idx++;                                                  //find item
        }

        if (_idx < _numberOfElements)
        {
            return _idx;                                             // return index
        }
        else
        {
            return -1;
        }
    }

    public bool Remove(T item)
    {
        _idx = 0;

        while ((!EqualityComparer<T>.Default.Equals(item, _internalStorage[_idx])) && (_idx < _numberOfElements))
        {
            _idx++;                                                  //find item index
        }

        return RemoveAt(_idx);                                       //Remove item with selected index
    }

    public bool RemoveAt(int index)
    {
        if ((index + 1) > _numberOfElements)                           //index out of range
        {
            return false;
        }

        while (index != (_numberOfElements - 1))                       //Shift elements to the right
        {
            _internalStorage[index] = _internalStorage[index + 1];
            index++;
        }
        _numberOfElements--;                                         //Decremant total number of elements
        _internalStorage[_numberOfElements] = default(T);                     //Set last one to zero
        return true;
    }

    //IEnumerable<T> implementation
    public IEnumerator<T> GetEnumerator()
    {
        return new GenericListEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class GenericListEnumerator<T> : IEnumerator<T>
{
    private GenericList<T> _collection;
    private int _curIndex;
    private T _curT;

    public GenericListEnumerator(GenericList<T> collection)
    {
        _collection = collection;
        _curIndex = -1;
        _curT = default(T);
    }

    public T Current
    {
        get
        {
            return _curT;
        }
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public void Dispose()
    {
        // throw new Exception("Not implemnted");
    }

    public bool MoveNext()
    {
        if (++_curIndex >= _collection.Count)   
        {
            return false;
        }
        else
        {
            _curT = _collection.GetElement(_curIndex);
        }
        return true;
    }

    public void Reset()
    {
        _curIndex = -1;
    }
}

