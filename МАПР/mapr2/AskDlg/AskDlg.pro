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
        staticText_ctl:setText(Text).

clauses
    getAnswer() = Answer :-
        answer(Answer).
%        retract(answer(_)).
    
% This code is maintained automatically, do not update it manually. 14:02:18-10.3.2010
facts
    buttonYes : button.
    buttonNo : button.
    staticText_ctl : textControl.

predicates
    generatedInitialize : ().
clauses
    generatedInitialize():-
        setFont(vpi::fontCreateByName("Tahoma", 8)),
        setText("AskDlg"),
        setRect(rct(50,40,214,110)),
        setModal(true),
        setDecoration(titlebar([closebutton()])),
        setState([wsf_NoClipSiblings]),
        buttonYes := button::new(This),
        buttonYes:setText("Yes"),
        buttonYes:setPosition(12, 46),
        buttonYes:setClickResponder(onButtonYesClick),
        buttonNo := button::new(This),
        buttonNo:setText("No"),
        buttonNo:setPosition(87, 46),
        buttonNo:setClickResponder(onButtonNoClick),
        staticText_ctl := textControl::new(This),
        staticText_ctl:setText(""),
        staticText_ctl:setPosition(4, 6),
        staticText_ctl:setSize(156, 20),
        staticText_ctl:setAlignment(alignCenter).
% end of automatic code
end implement askDlg
