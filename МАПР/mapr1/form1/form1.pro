/*****************************************************************************

                        Copyright (c) 2010 

******************************************************************************/

implement form1
    inherits formWindow
    open core, vpiDomains, askDlg

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
    xpositive : (symbol).
    xnegative : (symbol).

predicates
do_expert_fruit : () determ.
do_consulting : () nondeterm.
ask:  (symbol) determ.
tree_is : (symbol) determ (o).
positive : (symbol) determ.
negative : (symbol) determ.
remember: (symbol,integer) determ. 
clear_facts: () nondeterm.

printHas: (symbol, integer) determ.

clauses

do_expert_fruit():-
    listbox1:add("Ответе на следующие вопросы."),
    do_consulting(),
    listbox1:add("Конец."),
    !.

do_consulting():-tree_is(X),!,listbox1:add(string::concat("А не ",X," ли это.")),clear_facts.
do_consulting():-listbox1:add("Неизвестное системе дерево."),clear_facts.

ask(Y):-
    Dl1 = askDlg::new(This),
    Dl1:setQuestion(string::concat("Имеет ли дерево ",Y," ?")),
    Dl1:show(),
    Reply = Dl1:getAnswer(),
    printHas(Y,Reply),
    remember(Y,Reply).

positive(Y):-xpositive(Y),!.
positive(Y):-not(negative(Y)),!,
    ask(Y).

negative(Y):-xnegative(Y),!.

remember(Y,1):-asserta(xpositive(Y)),!.
remember(Y,-1):-asserta(xnegative(Y)),fail.

clear_facts():-retract(xpositive(_)),succeed.
clear_facts():-retract(xnegative(_)),succeed.

printHas(Y, 1) :- listbox1:add(string::concat("Дерево имеет ", Y, ".")),!.
printHas(Y,-1) :- listbox1:add(string::concat("Дерево не имеет ", Y,".")),!.

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

% This code is maintained automatically, do not update it manually. 00:49:12-11.3.2010
facts
    listbox1 : listBox.
    pushButton_ctl : button.

predicates
    generatedInitialize : ().
clauses
    generatedInitialize():-
        setFont(vpi::fontCreateByName("Tahoma", 8)),
        setText("Lab1 ЭС \"Фруктовые деревья\""),
        setRect(rct(50,40,258,218)),
        setDecoration(titlebar([closebutton(),maximizebutton(),minimizebutton()])),
        setBorder(sizeBorder()),
        setState([wsf_ClipSiblings,wsf_ClipChildren]),
        menuSet(noMenu),
        addShowListener(generatedOnShow),
        setCloseResponder(onClose),
        listbox1 := listBox::new(This),
        listbox1:setPosition(4, 26),
        listbox1:setSize(200, 146),
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
