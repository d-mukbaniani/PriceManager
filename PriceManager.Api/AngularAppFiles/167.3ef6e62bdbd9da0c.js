"use strict";(self.webpackChunkGPI_task=self.webpackChunkGPI_task||[]).push([[167],{3167:(M,u,e)=>{e.r(u),e.d(u,{SignInModule:()=>S});var a=e(6895),i=e(433),c=e(5765),l=e(8553),p=e(1407),n=e(8256),m=e(892),d=e(235),f=e(6742);function h(t,s){1&t&&(n.TgZ(0,"p",5),n._uU(1,"Username or Password is Incorrect"),n.qZA())}const I=[{path:"",component:(()=>{class t{constructor(o,r,g){this.fb=o,this.router=r,this.httpAuthService=g,this.error=!1}ngOnInit(){this.signInFormBuilder()}signInFormBuilder(){this.signInform=this.fb.group({userName:new i.NI("",{validators:[i.kI.required],updateOn:"blur"}),password:new i.NI("",{validators:[i.kI.required],updateOn:"blur"})})}signIn(){this.signInform.valid?this.httpAuthService.signIn(this.signInform.value).subscribe(r=>{this.httpAuthService.isUserLoggedIn$.next(!0),this.httpAuthService.seToken(r),this.router.navigate(["/dashboard"])}):this.markFormAsDirty(this.signInform)}markFormAsDirty(o){Object.keys(o.controls).forEach(r=>{o.get(r)?.markAsDirty()})}}return t.\u0275fac=function(o){return new(o||t)(n.Y36(i.qu),n.Y36(p.F0),n.Y36(m.e))},t.\u0275cmp=n.Xpm({type:t,selectors:[["app-sign-in"]],decls:10,vars:4,consts:[["class","error",4,"ngIf"],[3,"formGroup"],["formControlName","userName","label","User Name","inputType","userName","inputId","userName",3,"control"],["formControlName","password","label","Password","inputType","password","inputId","password",3,"control"],["buttonClass","sign-in",3,"click"],[1,"error"]],template:function(o,r){1&o&&(n.TgZ(0,"main")(1,"section"),n.YNc(2,h,2,0,"p",0),n.TgZ(3,"form",1)(4,"h1"),n._uU(5,"Sign In"),n.qZA(),n._UZ(6,"app-input",2)(7,"app-input",3),n.TgZ(8,"app-button",4),n.NdJ("click",function(){return r.signIn()}),n._uU(9,"Sign-in"),n.qZA()()()()),2&o&&(n.xp6(2),n.Q6J("ngIf",r.error),n.xp6(1),n.Q6J("formGroup",r.signInform),n.xp6(3),n.Q6J("control",r.signInform.get("userName")),n.xp6(1),n.Q6J("control",r.signInform.get("password")))},dependencies:[a.O5,i._Y,i.JJ,i.JL,i.sg,i.u,d.a,f.r],styles:["main[_ngcontent-%COMP%]   section[_ngcontent-%COMP%]{position:absolute;top:calc(50% - 280px);left:0;right:0;width:60%;max-width:800px;margin:0 auto;box-shadow:0 1px 42px #9aabffbf;border-radius:10px;padding:100px 70px}main[_ngcontent-%COMP%]   section[_ngcontent-%COMP%]   p[_ngcontent-%COMP%]{color:red;position:absolute;top:50px;left:0;right:0;margin:0 auto;text-align:center}main[_ngcontent-%COMP%]   section[_ngcontent-%COMP%]   h1[_ngcontent-%COMP%]{margin:0 0 30px;text-align:center;font-size:30px}main[_ngcontent-%COMP%]   section[_ngcontent-%COMP%]   span[_ngcontent-%COMP%]{position:absolute;display:inline-block;color:red;transform:translateY(-20px);font-size:13px}main[_ngcontent-%COMP%]   section[_ngcontent-%COMP%]   h5[_ngcontent-%COMP%]{color:red;text-align:center;position:absolute;bottom:100px;left:0;right:0;margin:0 auto}"]}),t})()}];let C=(()=>{class t{}return t.\u0275fac=function(o){return new(o||t)},t.\u0275mod=n.oAB({type:t}),t.\u0275inj=n.cJS({imports:[p.Bz.forChild(I),p.Bz]}),t})(),S=(()=>{class t{}return t.\u0275fac=function(o){return new(o||t)},t.\u0275mod=n.oAB({type:t}),t.\u0275inj=n.cJS({imports:[a.ez,i.UX,C,l.g,c.h,a.ez]}),t})()}}]);