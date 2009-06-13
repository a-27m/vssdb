// MyList.h: interface for the CMyList class,
//           implementation of the CMyList class.
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_MYLIST_H__A1C39470_EEDF_46C7_9128_71F610CB4D59__INCLUDED_)
#define AFX_MYLIST_H__A1C39470_EEDF_46C7_9128_71F610CB4D59__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define NOT_FOUND_IN_LIST	-1

template <class T>
class CMyList
{
	struct	Node
	{
		T data;
		Node * next;
	};
	Node*	first;
	int	count;
public:
	class Iterator
	{
		Node*	Current;
		int		Offset;
	public:
		void   GoNext(void);
		void   GoNext(int n);
		Node * GetCurrent(void) {return Current;}
		int    GetOffset(void)	{return Offset;	}

		//bool   EOL(void);
		Iterator(CMyList *List);
		bool EOL;
	};
public:
	CMyList();
	virtual ~CMyList();
public:
	void AddFirst(T dat);
	void AddFirst(CMyList * List);
	void AddLast (T dat);
	void AddLast (CMyList * List);

	void RemoveFirst(void);
	void RemoveLast (void);

	int	GetCount (void);
	T*	GetByIndex(int index);

	int	FindOffset(T);

	template<typename T> friend CArchive& operator<< (CArchive&, CMyList<T> &Ob);
	template<typename T> friend CArchive& operator>> (CArchive&, CMyList<T> &Ob);
	//void Serialize(CArchive &ar);AFXAPI 

	friend class Iterator;
};

// Construction/Destruction
template <class T>
CMyList<T>::CMyList()
{
	first=NULL;count=0;
}

template <class T>
CMyList<T>::~CMyList()
{
	Node * curr = first;
	for(int i=count-1; i>=0; i--)
	{
		curr = first;
		for(int j=0; j<i; j++)
			curr = curr->next;
		delete curr;
	}
	first = NULL;
	count = 0;
}

// Other
template <class T>
int CMyList<T>::GetCount()
{
	return count;
}

template <class T>
void CMyList<T>::AddFirst(T dat)
{
	Node* t=new Node;
	t->data=dat;
	t->next=first;
	first=t;count++;
}

template <class T>
void CMyList<T>::AddFirst(CMyList * List)
{
	Node* tmp;
	tmp=List->first;
	while(tmp->next!=NULL)	{tmp=tmp->next;count++;}//goto the end of 'List'

	tmp->next=this->first;
}

template <class T>
void CMyList<T>::AddLast(CMyList * List) //source OK
{
	Node* tmp;
	tmp=this->first;
	while(tmp->next!=NULL) {tmp=tmp->next;}
	tmp->next=List->first;
	while(tmp->next!=NULL) {count++;}// <- walk to the end of added list
}

template <class T>
void CMyList<T>::AddLast(T dat)
{
	if (count==0)
	{
		AddFirst(dat);
		return;	
	}
	Node* tmp = new Node;
	tmp = this->first;
	while(tmp->next != NULL)
	{
		tmp = tmp->next;
	}

	Node *n = new Node;
	n->data = dat;
	n->next = NULL;
	tmp->next = n;
	count++;
}

template <class T>
void CMyList<T>::RemoveFirst(void)
{
	Node* t = first;
	first=first->next;
	delete t;	//release memory
}

template <class T>
void CMyList<T>::RemoveLast(void)
{
	Node* tmp,w;
	tmp = this->first;
	while( tmp->next != NULL )
	{
		tmp = tmp->next;
		w = tmp;
	}

	delete tmp;
	tmp = NULL;//released memory
}

template <class T>
T* CMyList<T>::GetByIndex(int index)
{
	Iterator i(this);
	i.GoNext(index);
	return & i.GetCurrent()->data;
}

template <class T>
int	CMyList<T>::FindOffset(T elem)
{
	for( Iterator i(this); !i.EOL; i.GoNext() )
		if (i.GetCurrent()->data == elem) return i.GetOffset();
	return NOT_FOUND_IN_LIST;
}



template <class T>
CArchive& operator<< (CArchive& ar, CMyList<T> &Ob)
{
	ar<<Ob.count;
	for(CMyList<T>::Iterator i(&Ob); !i.EOL; i.GoNext())
		ar<<i.GetCurrent()->data;
	return ar;
}

template <class T>
CArchive& operator>> (CArchive& ar, CMyList<T> &Ob)
{
	T* dat;int c=0;
	ar>>c;
	while(c-- > 0)
	{
		dat = new T;
		ar>>*dat;
		Ob.AddLast(*dat);
		delete dat;
	}
	return ar;
}

//template <class T>
//void CMyList<T>::Serialize(CArchive &ar)
//{
//	if (ar.IsStoring())
//	{
//		ar<<*this;
//	}
//	else
//	{
//		ar>>*this;
//	}
//}

//////////////////////////////////////////////////////////////////////
// member class Iterator
//////////////////////////////////////////////////////////////////////
template <class T>
CMyList<T>::Iterator::Iterator(CMyList *List)
{
	Current = List->first;
	Offset=0;
	EOL = (List->count == 0);
}

template <class T>
void CMyList<T>::Iterator::GoNext(void)
{
	if (EOL) return;
	Current=Current->next;
	if (Current==NULL) EOL=true;
	Offset++;
}

template <class T>
void CMyList<T>::Iterator::GoNext(int n)
{
	for( int i = 0;
		(i<n) && (!EOL);
		this-> GoNext(), i++ );
}

#endif // !defined(AFX_MYLIST_H__A1C39470_EEDF_46C7_9128_71F610CB4D59__INCLUDED_)
