/*****************************************************************************

                        Copyright (c) 2010 

******************************************************************************/

implement main
    open core

constants
    className = "main".
    classVersion = "".

clauses
    classInfo(className, classVersion).

clauses
    run():-
        TaskWindow1 = taskWindow::new(),
        TaskWindow1:show().
end implement main

goal
    mainExe::run(main::run).
