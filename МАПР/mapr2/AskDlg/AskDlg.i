/*****************************************************************************

                        Copyright (c) 2010 

******************************************************************************/

interface askDlg supports dialog
    open core
    
predicates
    getAnswer : () -> real Answer determ.
 predicates
	setQuestion : (string Text).

end interface askDlg