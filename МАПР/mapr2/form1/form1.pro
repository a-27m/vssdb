/*****************************************************************************

                        Copyright (c) 2010 

******************************************************************************/

implement form1
    inherits formWindow
    open core, math, vpiDomains, askDlg

constants
    className = "form1/form1".
    classVersion = "".

clauses
    classInfo(className, classVersion).

clauses
    display(Parent) = Form :-
        Form = new(Parent),
        Form:show().

clauses
    new(Parent):-
        formWindow::new(Parent),
        generatedInitialize().

facts
    xpositive : (symbol,real).
    xnegative : (symbol,real).

predicates
do_expert_fruit : () determ.
do_consulting : () nondeterm.

ask:  (symbol,real) determ.
tree_is : (symbol,real) determ (o,o).
positive : (real,symbol,real) determ (o,i,i) (i,i,i).
negative : (real,symbol,real) determ (o,i,i) (i,i,i).
remember: (symbol,real) determ. 

clear_facts: () nondeterm.
printHas: (symbol, real) determ.

clauses

do_expert_fruit():-
    listbox1:add("Ответе на следующие вопросы."),
    do_consulting(),
    listbox1:add("Конец."),
    !.

do_consulting():-tree_is(X,P),!,listbox1:add(string::concat("На ", P*100, "% это ", X)),clear_facts.
do_consulting():-listbox1:add("Неизвестное системе дерево."),clear_facts.

printHas(Y, P) :- P>=0,
    listbox1:add(string::concat("Дерево имеет ", Y,". Достоверность: ", P)),!.
printHas(Y, P) :- P<0,
    listbox1:add(string::concat("Дерево не имеет ", Y,". Достоверность: ", P)),!.
    
ask(Y,Reply):-
    Dl1 = askDlg::new(This),
    Dl1:setQuestion(string::concat("Имеет ли дерево ",Y," ?")),
    Dl1:show(),
    Reply = Dl1:getAnswer(),
    printHas(Y,Reply),
    remember(Y,Reply).

positive(Pout,Y,P):-xpositive(Y,Pout),Pout=min(P,Pout),!.
positive(Pout,Y,P):-not(negative(Pout,Y,P)),Pout=P,!,
    ask(Y,Pout).

negative(Pout, Y,P):-xnegative(Y,P),Pout=P,!.

remember(Y,P):-P>=0,asserta(xpositive(Y,P)),!.
remember(Y,P):- P<0,asserta(xnegative(Y,P)),fail.

clear_facts():-
    retract(xpositive(_,_)),
    retract(xnegative(_,_)).

tree_is("Дуб",P):-
    positive(P,"Лиственное",0.9),
    positive(P,"Твердая",0.7),
    positive(P,"Серо-коричневая",0.5),
    positive(P,"Мелкая текстура",0.8),!.
tree_is("Бук",P):-
    positive(P,"Лиственная",0.9),
    positive(P,"Твердая",0.65),
    positive(P,"Светло-красная",0.7),
    positive(P,"Крупная текстура",0.81),!.
/*
tree_is("Слива"):-
    positive("плод вытянутой формы"),
    positive("только одну косточку"),
    positive("ланцетовидные листья"),
    positive("листья с зубчатым краем"),!.
tree_is("Яблоня"):-
    positive("округлый плод"),
    positive("несколько семян(косточек)"),
    positive("листья округлой формы"),!.
tree_is("Груша"):-
    positive("плод вытянутой формы"),
    positive("несколько семян(косточек)"),
    positive("листья округлой формы"),!.
tree_is("Айва"):-
    positive("колючки"),
    positive("округлый плод"),
    positive("несколько семян(косточек)"),
    positive("листья округлой формы"),!.
tree_is("Абрикос"):-
    positive("бархатистый плод"),
    positive("округлый плод"),
    positive("съедобные семена(косточки)"),
    positive("только одну косточку"),
    positive("листья округлой формы"),
    positive("листья с зубчатым краем"),!.
tree_is("Персик"):-
    positive("бархатистый плод"),
    positive("округлый плод"),
    positive("только одну косточку"),
    positive("ланцетовидные листья"),
    positive("листья с зубчатым краем"),!.
tree_is("Вишня"):-
    positive("округлый плод"),
    positive("только одну косточку"),
    positive("листья с зубчатым краем"),!.
tree_is("Кизил"):-
    positive("плод вытянутой формы"),
    positive("только одну косточку"),
    positive("листья округлой формы"),!.
*/

predicates
    onPushButtonClick : button::clickResponder.
clauses
    onPushButtonClick(_Source) = button::noAction :-
         do_expert_fruit(),!.
    onPushButtonClick(_) = button::noAction :-!.

predicates
    onClose : frameDecoration::closeResponder.
clauses
    onClose(_Source) = frameDecoration::defaultCloseHandling./* :-
        This:close().*/

% This code is maintained automatically, do not update it manually. 13:50:24-10.3.2010
facts
    listbox1 : listBox.
    pushButton_ctl : button.

predicates
    generatedInitialize : ().
clauses
    generatedInitialize():-
        setFont(vpi::fontCreateByName("Tahoma", 8)),
        setText("Lab 1 \"Фруктовые деревья\""),
        setRect(rct(50,40,254,218)),
        setDecoration(titlebar([closebutton(),maximizebutton(),minimizebutton()])),
        setBorder(sizeBorder()),
        setState([wsf_ClipSiblings,wsf_ClipChildren]),
        menuSet(noMenu),
        addShowListener(generatedOnShow),
        setCloseResponder(onClose),
        listbox1 := listBox::new(This),
        listbox1:setPosition(4, 26),
        listbox1:setSize(196, 146),
        listbox1:setSort(false),
        pushButton_ctl := button::new(This),
        pushButton_ctl:setText("Начать"),
        pushButton_ctl:setPosition(4, 4),
        pushButton_ctl:setClickResponder(onPushButtonClick),
        setDefaultButton(pushButton_ctl).

predicates
    generatedOnShow: window::showListener.
clauses
    generatedOnShow(_,_):-
        succeed.
% end of automatic code
end implement form1
