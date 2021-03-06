/*****************************************************************************

                        Copyright (c) 2010 

******************************************************************************/

implement askDlg
    inherits dialog
    open core, vpiDomains

constants
    className = "AskDlg/askDlg".
    classVersion = "".

clauses
    classInfo(className, classVersion).

clauses
    display(Parent) = Dialog :-
        Dialog = new(Parent),
        Dialog:show().

clauses
    new(Parent) :-
        dialog::new(Parent),
        generatedInitialize().
%        answer:=0.

facts
    answer : (integer) determ.

predicates
    onButtonYesClick : button::clickResponder.
clauses
    onButtonYesClick(_Source) = button::defaultAction :-
        assert(answer(1)),
        close().
    
predicates
    onButtonNoClick : button::clickResponder.
clauses
    onButtonNoClick(_Source) = button::defaultAction :-
        assert(answer(-1)),
        close().
        
clauses
    setQuestion(Text) :-
    	edit_ctl:setText(Text).

clauses
    getAnswer() = Answer :-
        answer(Answer).
%        retract(answer(_)).
    
% This code is maintained automatically, do not update it manually. 23:53:08-9.3.2010
facts
    edit_ctl : editControl.
    buttonYes : button.
    buttonNo : button.

predicates
    generatedInitialize : ().
clauses
    generatedInitialize():-
        setFont(vpi::fontCreateByName("Tahoma", 8)),
        setText("AskDlg"),
        setRect(rct(50,40,214,126)),
        setModal(true),
        setDecoration(titlebar([closebutton()])),
        setState([wsf_NoClipSiblings]),
        edit_ctl := editControl::new(This),
        edit_ctl:setText("Edit"),
        edit_ctl:setPosition(15, 12),
        edit_ctl:setWidth(128),
        edit_ctl:setHeight(32),
        edit_ctl:setAlignment(alignCenter),
        edit_ctl:setMultiLine(),
        edit_ctl:setReadOnly(),
        buttonYes := button::new(This),
        buttonYes:setText("Yes"),
        buttonYes:setPosition(15, 62),
        buttonYes:setClickResponder(onButtonYesClick),
        buttonNo := button::new(This),
        buttonNo:setText("No"),
        buttonNo:setPosition(87, 62),
        buttonNo:setClickResponder(onButtonNoClick).
% end of automatic code
end implement askDlg
