/*
 * @author    RocketTheme http://www.rockettheme.com
 * @copyright Copyright (C) 2007 - 2012 RocketTheme, LLC
 * @license   http://www.gnu.org/licenses/gpl-2.0.html GNU/GPLv2 only
 */
((function(){if(typeof this.RokSprocket=="undefined"){this.RokSprocket={};}else{Object.merge(this.RokSprocket,{Features:null});}Element.implement({styles:function(){var c=moofx(this),b=c.style.apply(c,arguments);
if(arguments.length==1&&typeof arguments[0]=="string"){return b;}return this;},moofx:function(){var b=moofx(this);b.animate.apply(b,arguments);return this;
}});var a=new Class({Implements:[Options,Events],animations:{},options:{data:"features",settings:{}},initialize:function(b){this.setOptions(b);this.data=this.options.data;
this.features=document.getElements("[data-"+this.data+"]");this.settings={};this.timers={};this.statuses={};},attach:function(b,c){b=typeOf(b)=="number"?document.getElements("[data-"+this.data+"="+this.getID(b)+"]"):b;
c=typeOf(c)=="string"?JSON.decode(c):c;var d=(b?new Elements([b]).flatten():this.features);d.each(function(e){e.store("roksprocket:"+this.data+":attached",true);
this.setSettings(e,c,"restore");var f={mouseenter:e.retrieve("roksprocket:"+this.data+":mouseenter",function(g){this.stopTimer.call(this,e);this.pause.call(this,e);
}.bind(this)),mouseleave:e.retrieve("roksprocket:"+this.data+":mouseleave",function(g){this.resume.call(this,e);this.startTimer.call(this,e);}.bind(this)),pagination:e.retrieve("roksprocket:"+this.data+":relay",function(g,h){this.toPane.call(this,g,e,h);
}.bind(this)),next:e.retrieve("roksprocket:"+this.data+":next",function(h,g){this.direction.call(this,h,e,g,"next");}.bind(this)),previous:e.retrieve("roksprocket:"+this.data+":previous",function(h,g){this.direction.call(this,h,e,g,"previous");
}.bind(this)),swipe:e.retrieve("roksprocket:"+this.data+":swipe",function(h,g){h.preventDefault();this.direction.call(this,h,e,g,(h.direction=="right"?"previous":"next"));
}.bind(this))};["mouseenter","mouseleave"].each(function(g){e.addEvent(g,f[g]);});["pagination","next","previous"].each(function(g,h){var j="[data-"+this.data+"-"+g+"]";
if(h>0){j+=", [data-"+g+"]";}e.addEvent("click:relay("+j+")",f[g]);},this);if(Browser.Features.Touch){e.addEvent("swipe",f.swipe);}if(this.getSettings(e).autoplay&&this.getSettings(e).autoplay.toInt()){this.startTimer(e);
}},this);},detach:function(b){b=typeOf(b)=="number"?document.getElements("[data-"+this.data+"="+this.getID(b)+"]"):b;var c=(b?new Elements([b]).flatten():this.features);
c.each(function(d){d.store("roksprocket:"+this.data+":attached",false);var e={mouseenter:d.retrieve("roksprocket:"+this.data+":mouseenter"),mouseleave:d.retrieve("roksprocket:"+this.data+":mouseleave"),pagination:d.retrieve("roksprocket:"+this.data+":relay"),next:d.retrieve("roksprocket:"+this.data+":next"),previous:d.retrieve("roksprocket:"+this.data+":previous")};
["mouseenter","mouseleave"].each(function(f){d.removeEvent(f,e[f]);});["pagination","next","previous"].each(function(f,g){var h="[data-"+this.data+"-"+f+"]";
if(g>0){h+=", [data-"+f+"]";}d.removeEvent("click:relay("+h+")",e[f]);},this);if(Browser.Features.Touch){d.removeEvent("swipe",e.swipe);}},this);},setSettings:function(b,e,d){var f=this.getID(b),c=Object.clone(this.options.settings);
if(!d||!this.settings["id-"+f]){this.settings["id-"+f]=Object.merge(c,e||c);}},getSettings:function(b){var c=this.getID(b);return this.settings["id-"+c];
},getContainer:function(b){if(!b){b=document.getElements("[data-"+this.data+"]");}if(typeOf(b)=="number"){b=document.getElement("[data-"+this.data+"="+b+"]");
}if(typeOf(b)=="string"){b=document.getElement(b);}return b;},getID:function(b){if(typeOf(b)=="number"){b=document.getElement("[data-"+this.data+"="+b+"]");
}if(typeOf(b)=="string"){b=document.getElement(b);}return b.get("data-"+this.data);},getRandom:function(){var c=Number.random(0,Object.getLength(this.animations)-1),b=Object.keys(this.animations);
return this.animations[b[c]];},toPosition:function(c,b){c=this.getContainer(c);if(!c.retrieve("roksprocket:"+this.data+":attached")){return;}this.stopTimer(c);
var d=c.getElements("[data-"+this.data+"-pagination]"),e=c.getElement("[data-"+this.data+"-pagination][class=active]");if(d[b]&&d[b].hasClass("active")){return;
}if(b>d.length-1){b=0;}if(b<0){b=d.length-1;}if(d.length){d.removeClass("active");d[b].addClass("active");}this.animate(c,e.get("data-"+this.data+"-pagination")-1,b);
},toPane:function(e,c,f){if(e){e.preventDefault();}c=this.getContainer(c);if(!c.retrieve("roksprocket:"+this.data+":attached")){return;}var d=c.getElements("[data-"+this.data+"-pagination]"),b=f.get("data-"+this.data+"-pagination")-1;
if(b==-1){throw new Error("RokSprocket Feature ["+this.data+']: Instance ID "'+c.get("data-"+this.data)+'", index not found.');}this.toPosition(c,b);},direction:function(e,b,d,c){if(e){e.preventDefault();
}c=c||"next";this[c](b,d);},next:function(d,e){d=this.getContainer(d);if(!d.retrieve("roksprocket:"+this.data+":attached")){return;}if(typeOf(d)=="elements"){return this.nextAll(d,e);
}var c=d.getElements("[data-"+this.data+"-pagination]"),g=c.filter(function(h){return h.hasClass("active");}),b=c.indexOf(g.length?g[0]:"")||0,f=b+1;if(f>c.length-1){f=0;
}this.toPosition(d,f);},nextAll:function(c,b){c=this.getContainer(c);if(typeOf(c)=="element"){return this.next(c,b);}c.each(function(d){this.next(d,b);
},this);},previous:function(d,e){d=this.getContainer(d);if(!d.retrieve("roksprocket:"+this.data+":attached")){return;}if(typeOf(d)=="elements"){return this.previousAll(d,e);
}var c=d.getElements("[data-"+this.data+"-pagination]"),g=c.filter(function(h){return h.hasClass("active");}),b=c.indexOf(g.length?g[0]:"")||0,f=b-1;if(f<0){f=c.length-1;
}this.toPosition(d,f);},previousAll:function(c,b){c=this.getContainer(c);if(typeOf(c)=="element"){return this.previous(c,b);}c.each(function(d){this.previous(d,b);
},this);},startTimer:function(c){c=this.getContainer(c);if(!c.retrieve("roksprocket:"+this.data+":attached")){return;}var e=this.getSettings(c),g=this.getID(c),b=this.statuses["id-"+g],f=e.autoplay.toInt(),d=(e.delay.toInt())*1000;
clearTimeout(this.timers["id-"+g]);if(f&&b!="pause"){this.timers["id-"+g]=this.next.delay(d,this,c);}},stopTimer:function(b){b=this.getContainer(b);var c=this.getID(b);
clearTimeout(this.timers["id-"+c]);},pause:function(b){b=this.getContainer(b);var c=this.getID(b);this.statuses["id-"+c]="pause";},resume:function(b){b=this.getContainer(b);
var c=this.getID(b);this.statuses["id-"+c]="play";},animate:function(b,h,i){var c=b.getElements("[data-"+this.data+"-content]"),g=b.getElements("[data-"+this.data+"-image]"),d=this.getSettings(b),j={content:{show:{display:"block","z-index":2},hide:{display:"none","z-index":1}},image:{show:{display:"block",position:"relative","z-index":2},hide:{display:"none",position:"absolute","z-index":1}}},f={content:c[h],image:g[h]},e={content:c[i],image:g[i]};
Object.each(f,function(l,k){f[k].style(j[k].hide);e[k].style(j[k].show);},this);if(d.autoplay&&d.autoplay.toInt()){this.startTimer(b);}},addAnimations:function(b){Object.merge(this.animations,b);
}});a.prototype.addAnimations({crossfade:{from:{opacity:0},to:{opacity:1}},fromTop:{from:{opacity:0,top:"-50%"},to:{opacity:1,top:"0%"}},fromTopLeft:{from:{opacity:0,top:"-50%",left:"-50%"},to:{opacity:1,top:"0%",left:"0%"}},fromTopRight:{from:{opacity:0,top:"-50%",right:"-50%"},to:{opacity:1,top:"0%",right:"0%"}},fromBottom:{from:{opacity:0,top:"50%"},to:{opacity:1,top:"0%"}},fromBottomLeft:{from:{opacity:0,top:"75%",left:"-75%"},to:{opacity:1,top:"0%",left:"0%"}},fromBottomRight:{from:{opacity:0,right:"-50%",top:"50%"},to:{opacity:1,right:"0%",top:"0%"}},fromLeft:{from:{opacity:0,left:"-50%"},to:{opacity:1,left:"0%"}},fromRight:{from:{opacity:0,right:"-50%"},to:{opacity:1,right:"0%"}}});
this.RokSprocket.Features=a;})());