/*****************************************************************************

                        Copyright (c) 2010 

******************************************************************************/
class askDlg : askDlg
    open core

predicates
    classInfo : core::classInfo.
    % @short Class information  predicate. 
    % @detail This predicate represents information predicate of this class.
    % @end

predicates
    display : (window Parent) -> askDlg AskDlg.

constructors
    new : (window Parent).

end class askDlg