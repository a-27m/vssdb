/*****************************************************************************

                        Copyright (c) 2010 

******************************************************************************/

implement statusLine
    open core, vpiDomains, vpiToolbar, resourceIdentifiers

constants
    className = "TaskWindow/Toolbars/statusLine".
    classVersion = "".

clauses
    classInfo(className, classVersion).

clauses
    create(Parent):-
        _ = vpiToolbar::create(style, Parent, controlList).

% This code is maintained automatically, do not update it manually. 10:26:05-5.3.2010
constants
    style : vpiToolbar::style = tb_bottom().
    controlList : vpiToolbar::control_list =
        [
        tb_text(idt_help_line,tb_context(),452,0,4,10,0x0,"")
        ].
% end of automatic code
end implement statusLine
