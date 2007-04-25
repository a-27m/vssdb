using System;
using System.Text;
using System.Collections.Generic;

//using automats;

namespace Polish
{
    public class Polish
    {
        public delegate double DoubleFunction(double x);

        string prefix;

        static string[,] TabFuns = new string[,] {
{"arcsinh","A"}, {"arccosh","B"}, {"arctanh","C"},
{"sinh","D"}, {"cosh","E"}, {"tanh","F"},
{"arccoth","G"}, {"coth","H"}, {"arcsec","I"},
{"arccsc","J"}, {"sec","K"}, {"csc","L"},
{"ln","M"}, {"lg","N"}, {"log2","O"},
{"arcsin","P"}, {"arccos","Q"}, {"arctan","R"},
{"sin","S"}, {"cos","T"}, {"tan","U"},
{"arccot","V"}, {"cot","W"}, {"exp","X"},
{"sqrt","Y"}, {"abs","Z"} };

        //         “ а б л и ц а   р е ш е н и й   ƒ и й к с т р а:
        static int[,] TabDyxtr = new int[,]{
{ 4, 1,  1,  1, 1, 5, 1, 6}, // @
{2, 2,  1,  1, 1, 2, 1, 6}, // +-
{2, 2,  2,  1, 1, 2, 1, 6}, // */     TOS
{2, 2,  2,  2, 1, 2, 1, 6}, // ^
{5, 1,  1,  1, 1, 3, 1, 6}, // (
{2, 2,  2,  2, 1, 7, 7, 6}
};// F
        /*решени€:
          1 = в стек
          2 = из стека - на выход
          3 = pop
          4 = exit
          5 = error: '(' или ')' !
          6 = вход - на выход
          7 = error: нет '(' после ф-ции! */

        int PosCh(char ch, string[] cha)
        {
            for (int i = 0; i < cha.Length; i++)
                if (ch == cha[i][0])
                    return i;
            return 0;
        }

        /*
function Error(i:integer):string;
begin
HasRes:=false;
 case i of
  0: begin err:=0;Result:='OK';end;
  1: begin err:=1;Result:='Error: brackets missing.';end;
  2: begin err:=2;Result:='Function without brackets.';end;
  3: begin err:=3;Result:='Illegal character(s) in the input.';end;
  10:begin err:=11;Result:='Error: stack is empty.';end;
  11:begin err:=11;Result:='Error: operand missing.';end;
 else Result:='Common recognizing of expression error.';
 end;
end;*/
        /*

procedure AlphCheck(var s:string);
var i :integer;
begin
err:=0;
i:=1;while i<=Length(s) do
     begin
       if NOT(s[i] in ['A'..'Z','a'..'z','0'..'9','(',')','+','-','*','/','^',',','.']) then
                                 begin  delete(s,i,1);dec(i);err:=3;end;
       inc(i);
     end;
end;*//*

function f_pop(stk:TVals;var top:integer):Extended;
begin
result:=stk[top];
dec(top);
if top<-1 then result:=0;//Error(11);
end;

function calc(stk:TVals;var top:integer;op:char):Extended;
var x,y:Extended;
begin

y:=0;Result:=0;
case op of
  'A'..'Z' : x:=f_pop(stk,top);
 else
  begin
    y:=f_pop(stk,top);
    x:=f_pop(stk,top);
    if Err<>0 then exit;
  end;
 end;
case op of
  'A': Result:=arcsinh(x);
  'B': if x>=1 then Result:=arccosh(x) else HasRes:=false;
  'C': if abs(x)>=1 then HasRes:=false else Result:=arctanh(x);
  'D': if abs(x)<20 then Result:=sinh(x) else HasRes:=false;
  'E': if abs(x)<20 then Result:=cosh(x) else HasRes:=false;
  'F': Result:=tanh(x);
  'G': if abs(x)<=1 then HasRes:=false else Result:=arccoth(x);
  'H': if IsZero(x,eps) then HasRes:=false else Result:=coth(x);
  'I': if abs(x)<=1 then HasRes:=false else Result:=arcsec(x);
  'J': if abs(x)<=1 then HasRes:=false else Result:=arccsc(x);
  'K': if IsZero(x-pi/2-int((x-pi/2)/pi)*pi,eps*100) then HasRes:=false else Result:=sec(x);
  'L': if IsZero(x-int(x/pi)*pi,eps*100) then HasRes:=false else Result:=csc(x);
  'M': if x>eps then Result:=ln(x) else HasRes:=false;
  'N': if x>eps then Result:=log10(x) else HasRes:=false;
  'O': if x>eps then Result:=log2(x) else HasRes:=false;
  'P': if abs(x)>1 then HasRes:=false else Result:=arcsin(x);
  'Q': if abs(x)>1 then HasRes:=false else Result:=arccos(x);
  'R': Result:=arctan(x);
  'S': Result:=sin(x);
  'T': Result:=cos(x);
  'U': if IsZero(x-pi/2-int((x-pi/2)/pi)*pi,eps*100) then HasRes:=false else Result:=tan(x);
  'V': Result:=arcCot(x);
  'W': if IsZero(x-int(x/pi)*pi,eps*100) then HasRes:=false else Result:=cot(x);
  'X': if x<20 then Result:=exp(x) else HasRes:=false;
  'Y': if x>=0 then Result:=sqrt(x) else HasRes:=false;
  'Z': Result:=abs(x);
  '+': Result:=x+y;
  '-': Result:=x-y;
  '*': if (x<>0)AND(y<>0) then
          begin
           if log10(abs(x))+log10(abs(y))<log10(MaxExtended) then
              Result:=x*y else HasRes:=false;
          end else Result:=0;
  '/': if not IsZero(y,eps) then Result:=x/y else HasRes:=false;
  '^': begin
         try
          if (x<>0)AND(y<>0) then Result:=Power(x,y) else HasRes:=false;
          except
            HasRes:=false;
         end;

       end;
//        end else Result:=Power(x,y);
  else Result:=1/0;
end;
end;

function IntoPolish(infix:string):string;
var   Stack :Tstk;
    i,ti,tj :integer;
     polish :string;
begin
err:=0;
Stack:=Tstk.Create('@');
infix:=infix+'@';
polish:='';i:=1;ti:=0;tj:=0;
// определ€ем индексы в таблице ƒийкстра
while i<=Length(infix) do
  begin{:::}
   case infix[i] of
    '@'      : tj:=1;    '+','-'  : tj:=2;
    '*','/'  : tj:=3;    '^'      : tj:=4;
    '('      : tj:=5;    ')'      : tj:=6;
    'A'..'Z' : tj:=7;    'a'..'z' : tj:=8;
   end;
   case Stack.top.next.ch of
    '@'      : ti:=1;    '+','-'  : ti:=2;
    '*','/'  : ti:=3;    '^'      : ti:=4;
    '('      : ti:=5;    'A'..'Z' : ti:=6;
   end;
   if (ti in [1..6])AND(tj in [1..8]) then
   case TabDyxtr[ti,tj] of
     1:Stack.Push(infix[i]);
     2:begin polish:=polish+Stack.Pop;dec(i);end;
     3:Stack.Pop;
     4:break;  //finished
     5:Error(1);
     6:polish:=polish+infix[i];
     7:Error(2);
   end;
   inc(i);
  end;{:::}
//польска€ запись получена если err=0
Result:=polish;
end;
                            // точнее array of char
function Evaluate(infix:string; ParamNames:string; ParamVals:array of Extended):Extended;
var   pars :TParams;
      vals :TVals;
    polish :string;
   i,j,n,v :integer;
        az :string;
    infixt :string;
     value :double;
     f_stk :TVals;
     f_top :integer;
         t: Extended;
begin
infixt:=infix;HasRes:=true;
az:='abcdefghijklmnopqrstuvwxyz'; //дл€ переменных
infix:=LowerCase(infix);
AlphCheck(infix); //проверили нa алфавит

//1.заполнение таблицы констант из параметров ф-ции
n:=0;
for i:=1 to length(ParamNames) do
  begin
    if pos(ParamNames[i],az)<>0 then
             begin
               delete(az,pos(ParamNames[i],az),1);// зан€ли
               {добавить в таблицу соответствий pars}
               pars[n]:=ParamNames[i];
               vals[n]:=ParamVals [i-1];
               inc(n);
             end;
  end;
//1.ends

// адаптаци€ разделител€ дробной части
for i:=1 to length(infix) do
  if infix[i] in ['.',','] then infix[i]:=DecimalSeparator;
while pos('))',infix)<>0 do
    insert(  '+0', infix, pos( '))', infix )+1  );

//2.«амена функций буквами заглавными AZ
for i:=1 to 26 do
  begin
   v:=pos(TabFuns[i,0],infix);
   while v<>0 do
          begin
            delete(infix,v,Length(TabFuns[i,0]));
            insert(TabFuns[i,1],infix,v);
            v:=pos(TabFuns[i,0],infix);
          end;
  end;
//2.ends

//3.«амена чисел буквами строчными az
// с конца
i:=Length(infix);
while i>0 do
    begin
     if infix[i] in ['0'..'9'] then
                begin
                  j:=i;
                  while (TryStrToFloat( copy(infix,j,i-j+1), value )=true)AND(j>0) do dec(j);
                  if i<>j then
                      begin
                       inc(j);
                       if infix[j] in ['+','-'] then inc(j);
                       if value<0 then value:=-value;
                       delete(infix,j,i-j+1);
                       insert(az[1],infix,j);
                       pars[n]:=az[1];{добавить в таблицу соответствий pars}
                       vals[n]:=value;
                       delete(az,1,1);// зан€ли первую попавшуюс€
                       inc(n);
                      end;
                  i:=j;
                end;
     dec(i);
    end;
//3.ends



polish:=IntoPolish(infix);

//таки непосредственно вычисление
i:=1;
f_top:=-1;//init fake stack
while (i<=length(polish))AND(HasRes) do
  begin
    if polish[i] in ['a'..'z'] then
        begin
          inc(f_top);
          f_stk[f_top]:=vals[PosCh(polish[i],pars)];
        end
    else begin
          t:=calc(f_stk,f_top,polish[i]);
          inc(f_top);
          if f_top<0 then
            begin
              Error(10);
              exit;
            end;
          f_stk[f_top]:=t;
         end;

    inc(i);
  end;

Result:=f_stk[0];
end;
*/

        Dictionary<char, DoubleFunction> functDic = new Dictionary<char,DoubleFunction>();

        public Polish(string infix)
        {
            infix = infix.ToUpper();

            double c;
            int Ai = -1, Si = 0;

            List<int> stack;

            for (int i = 0; i < infix.Length; i++)
            {
                Ai = AiFromInfix(infix);

                char s = infix[i];
            }
        }

        private int AiFromInfix(string infix)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}