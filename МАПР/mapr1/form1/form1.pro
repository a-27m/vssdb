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
    Dl1:setQuestion(string::concat("Оно ",Y," ?")),
    Dl1:show(),
    Reply = Dl1:getAnswer(),
    remember(Y,Reply).

positive(Y):-xpositive(Y),!.
positive(Y):-not(negative(Y)),!,
    ask(Y).

negative(Y):-xnegative(Y),!.

remember(Y,1):-asserta(xpositive(Y)),!.
remember(Y,-1):-asserta(xnegative(Y)),fail.

clear_facts():-retract(xpositive(_)),succeed.
clear_facts():-retract(xnegative(_)),succeed.

tree_is("Дуб"):-
    positive("Лиственное"),
    positive("Твердая"),
    positive("Серо-коричневая"),
    positive("Мелкая текстура"),!.
tree_is("Бук"):-
    positive("Лиственная"),
    positive("Твердая"),
    positive("Светло-красная"),
    positive("Крупная текстура"),!.
tree_is("Осина"):-
    positive("Лиственная"),
    positive("Мягкая"),
    positive("Светлая"),
    positive("Мелкая текстура"),!.
tree_is("Тис"):-
    positive("Лиственная"),
    positive("Очень твердая"),
    positive("Темная"),!.
tree_is("Ель"):-
    positive("Хвойная"),
    positive("Мягкая"),
    positive("Светлая"),
    positive("Смолистая"),!.
tree_is("Сосна"):-
    positive("Хвойная"),
    positive("Мягкая"),
    positive("Светлая"),
    positive("Очень cмолистая"),!.
tree_is("Столб"):-
    positive("Не дерево"),
    positive("Очень твердая"),!.

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

% This code is maintained automatically, do not update it manually. 22:46:11-9.3.2010
facts
    listbox1 : listBox.
    pushButton_ctl : button.

predicates
    generatedInitialize : ().
clauses
    generatedInitialize():-
        setFont(vpi::fontCreateByName("Tahoma", 8)),
        setText("Lab1 \"Фруктовые деревья\""),
        setRect(rct(50,40,206,218)),
        setDecoration(titlebar([closebutton(),maximizebutton(),minimizebutton()])),
        setBorder(sizeBorder()),
        setState([wsf_ClipSiblings,wsf_ClipChildren]),
        menuSet(noMenu),
        addShowListener(generatedOnShow),
        setCloseResponder(onClose),
        listbox1 := listBox::new(This),
        listbox1:setPosition(4, 26),
        listbox1:setSize(148, 146),
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
