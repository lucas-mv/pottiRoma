webpackJsonp([18],{UcQK:function(n,l,e){"use strict";Object.defineProperty(l,"__esModule",{value:!0});var o=e("LMZF"),d=(e("6lRS"),function(){}),t=e("8ly9"),u=e("lvpt"),a=e("ulOE"),r=e("Lpd/"),i=e("j5BN"),s=e("0nO6"),c=e("SlD5"),m=e("V8+5"),p=e("ESfO"),v=e("ghl+"),g=e("8Xfy"),h=e("PnL1"),f=e("4TbM"),_=function(){function n(n,l){this.gamificationService=n,this.toastr=l}return n.prototype.ngOnInit=function(){var n=this;this.loading=!0,this.gamificationService.getCurrentGamificationPoints().then(function(l){n.loading=!1,""!==l.message?n.toastr.error("Ocorreu um erro ao buscar os par\xe2metros atuais do jogo."):(n.registerClients=l.gamificationPoints.RegisterNewClients,n.numberOfSales=l.gamificationPoints.SalesNumber,n.averageTicketValue=l.gamificationPoints.AverageTicket,n.registerReseller=l.gamificationPoints.InviteFlower,n.itensPerSale=l.gamificationPoints.RegisterNewClients)})},n.prototype.updateGamificationPoints=function(){var n=this;this.loading=!0,this.gamificationService.updateGamificationPoints(this.averageTicketValue,this.registerClients,this.numberOfSales,this.itensPerSale,this.registerReseller).then(function(l){n.loading=!1,""!==l.message?n.toastr.error(l.message):n.toastr.success("Par\xe2metros do jogo atualizados com sucesso!")})},n}(),b=o["\u0275crt"]({encapsulation:0,styles:[[".game-parameters-container[_ngcontent-%COMP%]{-webkit-box-orient:vertical;-webkit-box-direction:normal;-ms-flex-direction:column;flex-direction:column}.game-parameters-container[_ngcontent-%COMP%], .game-parameters-container[_ngcontent-%COMP%]   .game-parameters-line[_ngcontent-%COMP%]{display:-webkit-box;display:-ms-flexbox;display:flex}.game-parameters-container[_ngcontent-%COMP%]   .game-parameters-line[_ngcontent-%COMP%]   .game-parameters-item[_ngcontent-%COMP%]{margin-left:12px;margin-right:12px;width:33%}"]],data:{animation:[{type:7,name:"routerTransition",definitions:[{type:0,name:"void",styles:{type:6,styles:{},offset:null},options:void 0},{type:0,name:"*",styles:{type:6,styles:{},offset:null},options:void 0},{type:1,expr:":enter",animation:[{type:6,styles:{transform:"translateY(100%)"},offset:null},{type:4,styles:{type:6,styles:{transform:"translateY(0%)"},offset:null},timings:"0.5s ease-in-out"}],options:null},{type:1,expr:":leave",animation:[{type:6,styles:{transform:"translateY(0%)"},offset:null},{type:4,styles:{type:6,styles:{transform:"translateY(-100%)"},offset:null},timings:"0.5s ease-in-out"}],options:null}],options:{}}]}});function C(n){return o["\u0275vid"](0,[(n()(),o["\u0275eld"](0,0,null,null,135,"div",[["class","margin-pages"]],[[24,"@routerTransition",0]],null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["\n    "])),(n()(),o["\u0275ted"](-1,null,["\n    "])),(n()(),o["\u0275eld"](3,0,null,null,4,"div",[],null,null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["\n        "])),(n()(),o["\u0275eld"](5,0,null,null,1,"h3",[["class","margin-pages"]],null,null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["Alterar Par\xe2metros do Jogo"])),(n()(),o["\u0275ted"](-1,null,["\n    "])),(n()(),o["\u0275ted"](-1,null,["\n    "])),(n()(),o["\u0275eld"](9,0,null,null,2,"ngx-loading",[],null,null,null,t.b,t.a)),o["\u0275did"](10,114688,null,0,u.b,[u.c],{show:[0,"show"],config:[1,"config"]},null),o["\u0275pod"](11,{backdropBorderRadius:0}),(n()(),o["\u0275ted"](-1,null,["\n    "])),(n()(),o["\u0275eld"](13,0,null,null,114,"div",[["class","game-parameters-container"]],null,null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["\n\n        "])),(n()(),o["\u0275eld"](15,0,null,null,64,"div",[["class","game-parameters-line"]],null,null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["\n\n            "])),(n()(),o["\u0275eld"](17,0,null,null,19,"mat-form-field",[["class","game-parameters-item mat-input-container mat-form-field"]],[[2,"mat-input-invalid",null],[2,"mat-form-field-invalid",null],[2,"mat-form-field-can-float",null],[2,"mat-form-field-should-float",null],[2,"mat-form-field-hide-placeholder",null],[2,"mat-form-field-disabled",null],[2,"mat-focused",null],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],null,null,a.b,a.a)),o["\u0275did"](18,7389184,null,7,r.a,[o.ElementRef,o.ChangeDetectorRef,[2,i.h]],null,null),o["\u0275qud"](335544320,1,{_control:0}),o["\u0275qud"](335544320,2,{_placeholderChild:0}),o["\u0275qud"](335544320,3,{_labelChild:0}),o["\u0275qud"](603979776,4,{_errorChildren:1}),o["\u0275qud"](603979776,5,{_hintChildren:1}),o["\u0275qud"](603979776,6,{_prefixChildren:1}),o["\u0275qud"](603979776,7,{_suffixChildren:1}),(n()(),o["\u0275ted"](-1,1,["\n                "])),(n()(),o["\u0275eld"](27,0,null,1,8,"input",[["class","mat-input-element mat-form-field-autofill-control"],["matInput",""],["placeholder","Cadastros de Clientes"],["type","number"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null],[2,"mat-input-server",null],[1,"id",0],[8,"placeholder",0],[8,"disabled",0],[8,"required",0],[8,"readOnly",0],[1,"aria-describedby",0],[1,"aria-invalid",0],[1,"aria-required",0]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"],[null,"change"],[null,"focus"]],function(n,l,e){var d=!0,t=n.component;return"input"===l&&(d=!1!==o["\u0275nov"](n,28)._handleInput(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,28).onTouched()&&d),"compositionstart"===l&&(d=!1!==o["\u0275nov"](n,28)._compositionStart()&&d),"compositionend"===l&&(d=!1!==o["\u0275nov"](n,28)._compositionEnd(e.target.value)&&d),"change"===l&&(d=!1!==o["\u0275nov"](n,29).onChange(e.target.value)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,29).onChange(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,29).onTouched()&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,34)._focusChanged(!1)&&d),"focus"===l&&(d=!1!==o["\u0275nov"](n,34)._focusChanged(!0)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,34)._onInput()&&d),"ngModelChange"===l&&(d=!1!==(t.registerClients=e)&&d),d},null,null)),o["\u0275did"](28,16384,null,0,s.d,[o.Renderer2,o.ElementRef,[2,s.a]],null,null),o["\u0275did"](29,16384,null,0,s.t,[o.Renderer2,o.ElementRef],null,null),o["\u0275prd"](1024,null,s.j,function(n,l){return[n,l]},[s.d,s.t]),o["\u0275did"](31,671744,null,0,s.o,[[8,null],[8,null],[8,null],[2,s.j]],{model:[0,"model"]},{update:"ngModelChange"}),o["\u0275prd"](2048,null,s.k,null,[s.o]),o["\u0275did"](33,16384,null,0,s.l,[s.k],null,null),o["\u0275did"](34,933888,null,0,c.b,[o.ElementRef,m.a,[2,s.k],[2,s.n],[2,s.g],i.d,[8,null]],{placeholder:[0,"placeholder"],type:[1,"type"]},null),o["\u0275prd"](2048,[[1,4]],r.b,null,[c.b]),(n()(),o["\u0275ted"](-1,1,["\n            "])),(n()(),o["\u0275ted"](-1,null,["\n            "])),(n()(),o["\u0275eld"](38,0,null,null,19,"mat-form-field",[["class","game-parameters-item mat-input-container mat-form-field"]],[[2,"mat-input-invalid",null],[2,"mat-form-field-invalid",null],[2,"mat-form-field-can-float",null],[2,"mat-form-field-should-float",null],[2,"mat-form-field-hide-placeholder",null],[2,"mat-form-field-disabled",null],[2,"mat-focused",null],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],null,null,a.b,a.a)),o["\u0275did"](39,7389184,null,7,r.a,[o.ElementRef,o.ChangeDetectorRef,[2,i.h]],null,null),o["\u0275qud"](335544320,8,{_control:0}),o["\u0275qud"](335544320,9,{_placeholderChild:0}),o["\u0275qud"](335544320,10,{_labelChild:0}),o["\u0275qud"](603979776,11,{_errorChildren:1}),o["\u0275qud"](603979776,12,{_hintChildren:1}),o["\u0275qud"](603979776,13,{_prefixChildren:1}),o["\u0275qud"](603979776,14,{_suffixChildren:1}),(n()(),o["\u0275ted"](-1,1,["\n                "])),(n()(),o["\u0275eld"](48,0,null,1,8,"input",[["class","mat-input-element mat-form-field-autofill-control"],["matInput",""],["placeholder","N\xfamero de Vendas"],["type","number"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null],[2,"mat-input-server",null],[1,"id",0],[8,"placeholder",0],[8,"disabled",0],[8,"required",0],[8,"readOnly",0],[1,"aria-describedby",0],[1,"aria-invalid",0],[1,"aria-required",0]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"],[null,"change"],[null,"focus"]],function(n,l,e){var d=!0,t=n.component;return"input"===l&&(d=!1!==o["\u0275nov"](n,49)._handleInput(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,49).onTouched()&&d),"compositionstart"===l&&(d=!1!==o["\u0275nov"](n,49)._compositionStart()&&d),"compositionend"===l&&(d=!1!==o["\u0275nov"](n,49)._compositionEnd(e.target.value)&&d),"change"===l&&(d=!1!==o["\u0275nov"](n,50).onChange(e.target.value)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,50).onChange(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,50).onTouched()&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,55)._focusChanged(!1)&&d),"focus"===l&&(d=!1!==o["\u0275nov"](n,55)._focusChanged(!0)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,55)._onInput()&&d),"ngModelChange"===l&&(d=!1!==(t.numberOfSales=e)&&d),d},null,null)),o["\u0275did"](49,16384,null,0,s.d,[o.Renderer2,o.ElementRef,[2,s.a]],null,null),o["\u0275did"](50,16384,null,0,s.t,[o.Renderer2,o.ElementRef],null,null),o["\u0275prd"](1024,null,s.j,function(n,l){return[n,l]},[s.d,s.t]),o["\u0275did"](52,671744,null,0,s.o,[[8,null],[8,null],[8,null],[2,s.j]],{model:[0,"model"]},{update:"ngModelChange"}),o["\u0275prd"](2048,null,s.k,null,[s.o]),o["\u0275did"](54,16384,null,0,s.l,[s.k],null,null),o["\u0275did"](55,933888,null,0,c.b,[o.ElementRef,m.a,[2,s.k],[2,s.n],[2,s.g],i.d,[8,null]],{placeholder:[0,"placeholder"],type:[1,"type"]},null),o["\u0275prd"](2048,[[8,4]],r.b,null,[c.b]),(n()(),o["\u0275ted"](-1,1,["\n            "])),(n()(),o["\u0275ted"](-1,null,["\n            "])),(n()(),o["\u0275eld"](59,0,null,null,19,"mat-form-field",[["class","game-parameters-item mat-input-container mat-form-field"]],[[2,"mat-input-invalid",null],[2,"mat-form-field-invalid",null],[2,"mat-form-field-can-float",null],[2,"mat-form-field-should-float",null],[2,"mat-form-field-hide-placeholder",null],[2,"mat-form-field-disabled",null],[2,"mat-focused",null],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],null,null,a.b,a.a)),o["\u0275did"](60,7389184,null,7,r.a,[o.ElementRef,o.ChangeDetectorRef,[2,i.h]],null,null),o["\u0275qud"](335544320,15,{_control:0}),o["\u0275qud"](335544320,16,{_placeholderChild:0}),o["\u0275qud"](335544320,17,{_labelChild:0}),o["\u0275qud"](603979776,18,{_errorChildren:1}),o["\u0275qud"](603979776,19,{_hintChildren:1}),o["\u0275qud"](603979776,20,{_prefixChildren:1}),o["\u0275qud"](603979776,21,{_suffixChildren:1}),(n()(),o["\u0275ted"](-1,1,["\n                "])),(n()(),o["\u0275eld"](69,0,null,1,8,"input",[["class","mat-input-element mat-form-field-autofill-control"],["matInput",""],["placeholder","Ticket M\xe9dio Valor"],["type","number"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null],[2,"mat-input-server",null],[1,"id",0],[8,"placeholder",0],[8,"disabled",0],[8,"required",0],[8,"readOnly",0],[1,"aria-describedby",0],[1,"aria-invalid",0],[1,"aria-required",0]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"],[null,"change"],[null,"focus"]],function(n,l,e){var d=!0,t=n.component;return"input"===l&&(d=!1!==o["\u0275nov"](n,70)._handleInput(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,70).onTouched()&&d),"compositionstart"===l&&(d=!1!==o["\u0275nov"](n,70)._compositionStart()&&d),"compositionend"===l&&(d=!1!==o["\u0275nov"](n,70)._compositionEnd(e.target.value)&&d),"change"===l&&(d=!1!==o["\u0275nov"](n,71).onChange(e.target.value)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,71).onChange(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,71).onTouched()&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,76)._focusChanged(!1)&&d),"focus"===l&&(d=!1!==o["\u0275nov"](n,76)._focusChanged(!0)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,76)._onInput()&&d),"ngModelChange"===l&&(d=!1!==(t.averageTicketValue=e)&&d),d},null,null)),o["\u0275did"](70,16384,null,0,s.d,[o.Renderer2,o.ElementRef,[2,s.a]],null,null),o["\u0275did"](71,16384,null,0,s.t,[o.Renderer2,o.ElementRef],null,null),o["\u0275prd"](1024,null,s.j,function(n,l){return[n,l]},[s.d,s.t]),o["\u0275did"](73,671744,null,0,s.o,[[8,null],[8,null],[8,null],[2,s.j]],{model:[0,"model"]},{update:"ngModelChange"}),o["\u0275prd"](2048,null,s.k,null,[s.o]),o["\u0275did"](75,16384,null,0,s.l,[s.k],null,null),o["\u0275did"](76,933888,null,0,c.b,[o.ElementRef,m.a,[2,s.k],[2,s.n],[2,s.g],i.d,[8,null]],{placeholder:[0,"placeholder"],type:[1,"type"]},null),o["\u0275prd"](2048,[[15,4]],r.b,null,[c.b]),(n()(),o["\u0275ted"](-1,1,["\n            "])),(n()(),o["\u0275ted"](-1,null,["\n            \n        "])),(n()(),o["\u0275ted"](-1,null,["\n        "])),(n()(),o["\u0275eld"](81,0,null,null,45,"div",[["class","game-parameters-line"]],null,null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["\n    \n            "])),(n()(),o["\u0275eld"](83,0,null,null,19,"mat-form-field",[["class","game-parameters-item mat-input-container mat-form-field"]],[[2,"mat-input-invalid",null],[2,"mat-form-field-invalid",null],[2,"mat-form-field-can-float",null],[2,"mat-form-field-should-float",null],[2,"mat-form-field-hide-placeholder",null],[2,"mat-form-field-disabled",null],[2,"mat-focused",null],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],null,null,a.b,a.a)),o["\u0275did"](84,7389184,null,7,r.a,[o.ElementRef,o.ChangeDetectorRef,[2,i.h]],null,null),o["\u0275qud"](335544320,22,{_control:0}),o["\u0275qud"](335544320,23,{_placeholderChild:0}),o["\u0275qud"](335544320,24,{_labelChild:0}),o["\u0275qud"](603979776,25,{_errorChildren:1}),o["\u0275qud"](603979776,26,{_hintChildren:1}),o["\u0275qud"](603979776,27,{_prefixChildren:1}),o["\u0275qud"](603979776,28,{_suffixChildren:1}),(n()(),o["\u0275ted"](-1,1,["\n                "])),(n()(),o["\u0275eld"](93,0,null,1,8,"input",[["class","mat-input-element mat-form-field-autofill-control"],["matInput",""],["placeholder","Cadastro de Flor Aliada"],["type","number"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null],[2,"mat-input-server",null],[1,"id",0],[8,"placeholder",0],[8,"disabled",0],[8,"required",0],[8,"readOnly",0],[1,"aria-describedby",0],[1,"aria-invalid",0],[1,"aria-required",0]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"],[null,"change"],[null,"focus"]],function(n,l,e){var d=!0,t=n.component;return"input"===l&&(d=!1!==o["\u0275nov"](n,94)._handleInput(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,94).onTouched()&&d),"compositionstart"===l&&(d=!1!==o["\u0275nov"](n,94)._compositionStart()&&d),"compositionend"===l&&(d=!1!==o["\u0275nov"](n,94)._compositionEnd(e.target.value)&&d),"change"===l&&(d=!1!==o["\u0275nov"](n,95).onChange(e.target.value)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,95).onChange(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,95).onTouched()&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,100)._focusChanged(!1)&&d),"focus"===l&&(d=!1!==o["\u0275nov"](n,100)._focusChanged(!0)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,100)._onInput()&&d),"ngModelChange"===l&&(d=!1!==(t.registerReseller=e)&&d),d},null,null)),o["\u0275did"](94,16384,null,0,s.d,[o.Renderer2,o.ElementRef,[2,s.a]],null,null),o["\u0275did"](95,16384,null,0,s.t,[o.Renderer2,o.ElementRef],null,null),o["\u0275prd"](1024,null,s.j,function(n,l){return[n,l]},[s.d,s.t]),o["\u0275did"](97,671744,null,0,s.o,[[8,null],[8,null],[8,null],[2,s.j]],{model:[0,"model"]},{update:"ngModelChange"}),o["\u0275prd"](2048,null,s.k,null,[s.o]),o["\u0275did"](99,16384,null,0,s.l,[s.k],null,null),o["\u0275did"](100,933888,null,0,c.b,[o.ElementRef,m.a,[2,s.k],[2,s.n],[2,s.g],i.d,[8,null]],{placeholder:[0,"placeholder"],type:[1,"type"]},null),o["\u0275prd"](2048,[[22,4]],r.b,null,[c.b]),(n()(),o["\u0275ted"](-1,1,["\n            "])),(n()(),o["\u0275ted"](-1,null,["\n            "])),(n()(),o["\u0275eld"](104,0,null,null,19,"mat-form-field",[["class","game-parameters-item mat-input-container mat-form-field"]],[[2,"mat-input-invalid",null],[2,"mat-form-field-invalid",null],[2,"mat-form-field-can-float",null],[2,"mat-form-field-should-float",null],[2,"mat-form-field-hide-placeholder",null],[2,"mat-form-field-disabled",null],[2,"mat-focused",null],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],null,null,a.b,a.a)),o["\u0275did"](105,7389184,null,7,r.a,[o.ElementRef,o.ChangeDetectorRef,[2,i.h]],null,null),o["\u0275qud"](335544320,29,{_control:0}),o["\u0275qud"](335544320,30,{_placeholderChild:0}),o["\u0275qud"](335544320,31,{_labelChild:0}),o["\u0275qud"](603979776,32,{_errorChildren:1}),o["\u0275qud"](603979776,33,{_hintChildren:1}),o["\u0275qud"](603979776,34,{_prefixChildren:1}),o["\u0275qud"](603979776,35,{_suffixChildren:1}),(n()(),o["\u0275ted"](-1,1,["\n                "])),(n()(),o["\u0275eld"](114,0,null,1,8,"input",[["class","mat-input-element mat-form-field-autofill-control"],["matInput",""],["placeholder","Pe\xe7as por Atendimento"],["type","number"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null],[2,"mat-input-server",null],[1,"id",0],[8,"placeholder",0],[8,"disabled",0],[8,"required",0],[8,"readOnly",0],[1,"aria-describedby",0],[1,"aria-invalid",0],[1,"aria-required",0]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"],[null,"change"],[null,"focus"]],function(n,l,e){var d=!0,t=n.component;return"input"===l&&(d=!1!==o["\u0275nov"](n,115)._handleInput(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,115).onTouched()&&d),"compositionstart"===l&&(d=!1!==o["\u0275nov"](n,115)._compositionStart()&&d),"compositionend"===l&&(d=!1!==o["\u0275nov"](n,115)._compositionEnd(e.target.value)&&d),"change"===l&&(d=!1!==o["\u0275nov"](n,116).onChange(e.target.value)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,116).onChange(e.target.value)&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,116).onTouched()&&d),"blur"===l&&(d=!1!==o["\u0275nov"](n,121)._focusChanged(!1)&&d),"focus"===l&&(d=!1!==o["\u0275nov"](n,121)._focusChanged(!0)&&d),"input"===l&&(d=!1!==o["\u0275nov"](n,121)._onInput()&&d),"ngModelChange"===l&&(d=!1!==(t.itensPerSale=e)&&d),d},null,null)),o["\u0275did"](115,16384,null,0,s.d,[o.Renderer2,o.ElementRef,[2,s.a]],null,null),o["\u0275did"](116,16384,null,0,s.t,[o.Renderer2,o.ElementRef],null,null),o["\u0275prd"](1024,null,s.j,function(n,l){return[n,l]},[s.d,s.t]),o["\u0275did"](118,671744,null,0,s.o,[[8,null],[8,null],[8,null],[2,s.j]],{model:[0,"model"]},{update:"ngModelChange"}),o["\u0275prd"](2048,null,s.k,null,[s.o]),o["\u0275did"](120,16384,null,0,s.l,[s.k],null,null),o["\u0275did"](121,933888,null,0,c.b,[o.ElementRef,m.a,[2,s.k],[2,s.n],[2,s.g],i.d,[8,null]],{placeholder:[0,"placeholder"],type:[1,"type"]},null),o["\u0275prd"](2048,[[29,4]],r.b,null,[c.b]),(n()(),o["\u0275ted"](-1,1,["\n            "])),(n()(),o["\u0275ted"](-1,null,["\n            "])),(n()(),o["\u0275eld"](125,0,null,null,0,"div",[["class","game-parameters-item"]],null,null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["\n        "])),(n()(),o["\u0275ted"](-1,null,["\n\n    "])),(n()(),o["\u0275ted"](-1,null,["\n\n    "])),(n()(),o["\u0275eld"](129,0,null,null,5,"div",[["class","form-center-layout"]],null,null,null,null,null)),(n()(),o["\u0275ted"](-1,null,["\n        "])),(n()(),o["\u0275eld"](131,0,null,null,2,"button",[["color","accent"],["mat-raised-button",""]],[[8,"disabled",0]],[[null,"click"]],function(n,l,e){var o=!0;return"click"===l&&(o=!1!==n.component.updateGamificationPoints()&&o),o},p.b,p.a)),o["\u0275did"](132,180224,null,0,v.b,[o.ElementRef,m.a,g.i],{color:[0,"color"]},null),(n()(),o["\u0275ted"](-1,0,["CONFIRMAR"])),(n()(),o["\u0275ted"](-1,null,["       \n    "])),(n()(),o["\u0275ted"](-1,null,["\n"])),(n()(),o["\u0275ted"](-1,null,["\n"]))],function(n,l){var e=l.component;n(l,10,0,e.loading,n(l,11,0,"14px")),n(l,31,0,e.registerClients),n(l,34,0,"Cadastros de Clientes","number"),n(l,52,0,e.numberOfSales),n(l,55,0,"N\xfamero de Vendas","number"),n(l,73,0,e.averageTicketValue),n(l,76,0,"Ticket M\xe9dio Valor","number"),n(l,97,0,e.registerReseller),n(l,100,0,"Cadastro de Flor Aliada","number"),n(l,118,0,e.itensPerSale),n(l,121,0,"Pe\xe7as por Atendimento","number"),n(l,132,0,"accent")},function(n,l){n(l,0,0,void 0),n(l,17,1,[o["\u0275nov"](l,18)._control.errorState,o["\u0275nov"](l,18)._control.errorState,o["\u0275nov"](l,18)._canLabelFloat,o["\u0275nov"](l,18)._shouldLabelFloat(),o["\u0275nov"](l,18)._hideControlPlaceholder(),o["\u0275nov"](l,18)._control.disabled,o["\u0275nov"](l,18)._control.focused,o["\u0275nov"](l,18)._shouldForward("untouched"),o["\u0275nov"](l,18)._shouldForward("touched"),o["\u0275nov"](l,18)._shouldForward("pristine"),o["\u0275nov"](l,18)._shouldForward("dirty"),o["\u0275nov"](l,18)._shouldForward("valid"),o["\u0275nov"](l,18)._shouldForward("invalid"),o["\u0275nov"](l,18)._shouldForward("pending")]),n(l,27,1,[o["\u0275nov"](l,33).ngClassUntouched,o["\u0275nov"](l,33).ngClassTouched,o["\u0275nov"](l,33).ngClassPristine,o["\u0275nov"](l,33).ngClassDirty,o["\u0275nov"](l,33).ngClassValid,o["\u0275nov"](l,33).ngClassInvalid,o["\u0275nov"](l,33).ngClassPending,o["\u0275nov"](l,34)._isServer,o["\u0275nov"](l,34).id,o["\u0275nov"](l,34).placeholder,o["\u0275nov"](l,34).disabled,o["\u0275nov"](l,34).required,o["\u0275nov"](l,34).readonly,o["\u0275nov"](l,34)._ariaDescribedby||null,o["\u0275nov"](l,34).errorState,o["\u0275nov"](l,34).required.toString()]),n(l,38,1,[o["\u0275nov"](l,39)._control.errorState,o["\u0275nov"](l,39)._control.errorState,o["\u0275nov"](l,39)._canLabelFloat,o["\u0275nov"](l,39)._shouldLabelFloat(),o["\u0275nov"](l,39)._hideControlPlaceholder(),o["\u0275nov"](l,39)._control.disabled,o["\u0275nov"](l,39)._control.focused,o["\u0275nov"](l,39)._shouldForward("untouched"),o["\u0275nov"](l,39)._shouldForward("touched"),o["\u0275nov"](l,39)._shouldForward("pristine"),o["\u0275nov"](l,39)._shouldForward("dirty"),o["\u0275nov"](l,39)._shouldForward("valid"),o["\u0275nov"](l,39)._shouldForward("invalid"),o["\u0275nov"](l,39)._shouldForward("pending")]),n(l,48,1,[o["\u0275nov"](l,54).ngClassUntouched,o["\u0275nov"](l,54).ngClassTouched,o["\u0275nov"](l,54).ngClassPristine,o["\u0275nov"](l,54).ngClassDirty,o["\u0275nov"](l,54).ngClassValid,o["\u0275nov"](l,54).ngClassInvalid,o["\u0275nov"](l,54).ngClassPending,o["\u0275nov"](l,55)._isServer,o["\u0275nov"](l,55).id,o["\u0275nov"](l,55).placeholder,o["\u0275nov"](l,55).disabled,o["\u0275nov"](l,55).required,o["\u0275nov"](l,55).readonly,o["\u0275nov"](l,55)._ariaDescribedby||null,o["\u0275nov"](l,55).errorState,o["\u0275nov"](l,55).required.toString()]),n(l,59,1,[o["\u0275nov"](l,60)._control.errorState,o["\u0275nov"](l,60)._control.errorState,o["\u0275nov"](l,60)._canLabelFloat,o["\u0275nov"](l,60)._shouldLabelFloat(),o["\u0275nov"](l,60)._hideControlPlaceholder(),o["\u0275nov"](l,60)._control.disabled,o["\u0275nov"](l,60)._control.focused,o["\u0275nov"](l,60)._shouldForward("untouched"),o["\u0275nov"](l,60)._shouldForward("touched"),o["\u0275nov"](l,60)._shouldForward("pristine"),o["\u0275nov"](l,60)._shouldForward("dirty"),o["\u0275nov"](l,60)._shouldForward("valid"),o["\u0275nov"](l,60)._shouldForward("invalid"),o["\u0275nov"](l,60)._shouldForward("pending")]),n(l,69,1,[o["\u0275nov"](l,75).ngClassUntouched,o["\u0275nov"](l,75).ngClassTouched,o["\u0275nov"](l,75).ngClassPristine,o["\u0275nov"](l,75).ngClassDirty,o["\u0275nov"](l,75).ngClassValid,o["\u0275nov"](l,75).ngClassInvalid,o["\u0275nov"](l,75).ngClassPending,o["\u0275nov"](l,76)._isServer,o["\u0275nov"](l,76).id,o["\u0275nov"](l,76).placeholder,o["\u0275nov"](l,76).disabled,o["\u0275nov"](l,76).required,o["\u0275nov"](l,76).readonly,o["\u0275nov"](l,76)._ariaDescribedby||null,o["\u0275nov"](l,76).errorState,o["\u0275nov"](l,76).required.toString()]),n(l,83,1,[o["\u0275nov"](l,84)._control.errorState,o["\u0275nov"](l,84)._control.errorState,o["\u0275nov"](l,84)._canLabelFloat,o["\u0275nov"](l,84)._shouldLabelFloat(),o["\u0275nov"](l,84)._hideControlPlaceholder(),o["\u0275nov"](l,84)._control.disabled,o["\u0275nov"](l,84)._control.focused,o["\u0275nov"](l,84)._shouldForward("untouched"),o["\u0275nov"](l,84)._shouldForward("touched"),o["\u0275nov"](l,84)._shouldForward("pristine"),o["\u0275nov"](l,84)._shouldForward("dirty"),o["\u0275nov"](l,84)._shouldForward("valid"),o["\u0275nov"](l,84)._shouldForward("invalid"),o["\u0275nov"](l,84)._shouldForward("pending")]),n(l,93,1,[o["\u0275nov"](l,99).ngClassUntouched,o["\u0275nov"](l,99).ngClassTouched,o["\u0275nov"](l,99).ngClassPristine,o["\u0275nov"](l,99).ngClassDirty,o["\u0275nov"](l,99).ngClassValid,o["\u0275nov"](l,99).ngClassInvalid,o["\u0275nov"](l,99).ngClassPending,o["\u0275nov"](l,100)._isServer,o["\u0275nov"](l,100).id,o["\u0275nov"](l,100).placeholder,o["\u0275nov"](l,100).disabled,o["\u0275nov"](l,100).required,o["\u0275nov"](l,100).readonly,o["\u0275nov"](l,100)._ariaDescribedby||null,o["\u0275nov"](l,100).errorState,o["\u0275nov"](l,100).required.toString()]),n(l,104,1,[o["\u0275nov"](l,105)._control.errorState,o["\u0275nov"](l,105)._control.errorState,o["\u0275nov"](l,105)._canLabelFloat,o["\u0275nov"](l,105)._shouldLabelFloat(),o["\u0275nov"](l,105)._hideControlPlaceholder(),o["\u0275nov"](l,105)._control.disabled,o["\u0275nov"](l,105)._control.focused,o["\u0275nov"](l,105)._shouldForward("untouched"),o["\u0275nov"](l,105)._shouldForward("touched"),o["\u0275nov"](l,105)._shouldForward("pristine"),o["\u0275nov"](l,105)._shouldForward("dirty"),o["\u0275nov"](l,105)._shouldForward("valid"),o["\u0275nov"](l,105)._shouldForward("invalid"),o["\u0275nov"](l,105)._shouldForward("pending")]),n(l,114,1,[o["\u0275nov"](l,120).ngClassUntouched,o["\u0275nov"](l,120).ngClassTouched,o["\u0275nov"](l,120).ngClassPristine,o["\u0275nov"](l,120).ngClassDirty,o["\u0275nov"](l,120).ngClassValid,o["\u0275nov"](l,120).ngClassInvalid,o["\u0275nov"](l,120).ngClassPending,o["\u0275nov"](l,121)._isServer,o["\u0275nov"](l,121).id,o["\u0275nov"](l,121).placeholder,o["\u0275nov"](l,121).disabled,o["\u0275nov"](l,121).required,o["\u0275nov"](l,121).readonly,o["\u0275nov"](l,121)._ariaDescribedby||null,o["\u0275nov"](l,121).errorState,o["\u0275nov"](l,121).required.toString()]),n(l,131,0,o["\u0275nov"](l,132).disabled||null)})}var y=o["\u0275ccf"]("app-game-parameters",_,function(n){return o["\u0275vid"](0,[(n()(),o["\u0275eld"](0,0,null,null,1,"app-game-parameters",[],null,null,null,C,b)),o["\u0275did"](1,114688,null,0,_,[h.a,f.k],null,null)],function(n,l){n(l,1,0)},null)},{},{},[]),q=e("hzkV"),F=e("Ai99"),R=e("Un6q"),w=e("l6RC"),S=e("ppgG"),P=e("4jwp"),k=e("OFGE"),E=e("w24y"),M=e("BtE/"),I=e("UHIZ"),x=function(){},O=e("tCmA"),T=e("0cZJ"),j=e("CZgk");e.d(l,"GameParametersModuleNgFactory",function(){return D});var D=o["\u0275cmf"](d,[],function(n){return o["\u0275mod"]([o["\u0275mpd"](512,o.ComponentFactoryResolver,o["\u0275CodegenComponentFactoryResolver"],[[8,[y,q.a,F.a]],[3,o.ComponentFactoryResolver],o.NgModuleRef]),o["\u0275mpd"](4608,R.n,R.m,[o.LOCALE_ID,[2,R.w]]),o["\u0275mpd"](6144,w.b,null,[R.c]),o["\u0275mpd"](4608,w.c,w.c,[[2,w.b]]),o["\u0275mpd"](4608,m.a,m.a,[]),o["\u0275mpd"](4608,g.k,g.k,[m.a]),o["\u0275mpd"](4608,g.j,g.j,[g.k,o.NgZone,R.c]),o["\u0275mpd"](136192,g.d,g.b,[[3,g.d],R.c]),o["\u0275mpd"](5120,g.n,g.m,[[3,g.n],[2,g.l],R.c]),o["\u0275mpd"](5120,g.i,g.g,[[3,g.i],o.NgZone,m.a]),o["\u0275mpd"](4608,S.b,S.b,[]),o["\u0275mpd"](4608,s.v,s.v,[]),o["\u0275mpd"](4608,u.c,u.c,[[2,"loadingConfig"]]),o["\u0275mpd"](4608,i.d,i.d,[]),o["\u0275mpd"](6144,i.g,null,[o.LOCALE_ID]),o["\u0275mpd"](4608,i.c,i.w,[[2,i.g]]),o["\u0275mpd"](5120,P.c,P.a,[[3,P.c],o.NgZone,m.a]),o["\u0275mpd"](5120,P.f,P.e,[[3,P.f],m.a,o.NgZone]),o["\u0275mpd"](4608,k.i,k.i,[P.c,P.f,o.NgZone,R.c]),o["\u0275mpd"](5120,k.e,k.j,[[3,k.e],R.c]),o["\u0275mpd"](4608,k.h,k.h,[P.f,R.c]),o["\u0275mpd"](5120,k.f,k.m,[[3,k.f],R.c]),o["\u0275mpd"](4608,k.c,k.c,[k.i,k.e,o.ComponentFactoryResolver,k.h,k.f,o.ApplicationRef,o.Injector,o.NgZone,R.c]),o["\u0275mpd"](5120,k.k,k.l,[k.c]),o["\u0275mpd"](5120,E.c,E.d,[k.c]),o["\u0275mpd"](4608,E.e,E.e,[k.c,o.Injector,[2,R.h],[2,E.b],E.c,[3,E.e],k.e]),o["\u0275mpd"](4608,M.h,M.h,[]),o["\u0275mpd"](5120,M.a,M.b,[k.c]),o["\u0275mpd"](512,R.b,R.b,[]),o["\u0275mpd"](512,I.o,I.o,[[2,I.t],[2,I.l]]),o["\u0275mpd"](512,x,x,[]),o["\u0275mpd"](512,O.a,O.a,[]),o["\u0275mpd"](512,w.a,w.a,[]),o["\u0275mpd"](256,i.e,!0,[]),o["\u0275mpd"](512,i.l,i.l,[[2,i.e]]),o["\u0275mpd"](512,m.b,m.b,[]),o["\u0275mpd"](512,i.v,i.v,[]),o["\u0275mpd"](512,g.a,g.a,[]),o["\u0275mpd"](512,v.c,v.c,[]),o["\u0275mpd"](512,S.c,S.c,[]),o["\u0275mpd"](512,T.c,T.c,[]),o["\u0275mpd"](512,s.s,s.s,[]),o["\u0275mpd"](512,s.h,s.h,[]),o["\u0275mpd"](512,u.a,u.a,[]),o["\u0275mpd"](512,r.c,r.c,[]),o["\u0275mpd"](512,c.c,c.c,[]),o["\u0275mpd"](512,i.x,i.x,[]),o["\u0275mpd"](512,i.o,i.o,[]),o["\u0275mpd"](512,j.g,j.g,[]),o["\u0275mpd"](512,P.b,P.b,[]),o["\u0275mpd"](512,k.g,k.g,[]),o["\u0275mpd"](512,E.i,E.i,[]),o["\u0275mpd"](512,M.i,M.i,[]),o["\u0275mpd"](512,d,d,[]),o["\u0275mpd"](1024,I.j,function(){return[[{path:"",component:_}]]},[]),o["\u0275mpd"](256,i.f,i.i,[])])})}});