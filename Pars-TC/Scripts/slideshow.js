/*
 * @author    RocketTheme http://www.rockettheme.com
 * @copyright Copyright (C) 2007 - 2012 RocketTheme, LLC
 * @license   http://www.gnu.org/licenses/gpl-2.0.html GNU/GPLv2 only
 */
((function(){if(typeof this.RokSprocket=="undefined"){this.RokSprocket={};}else{Object.merge(this.RokSprocket,{Slideshow:null});}var a=new Class({Extends:this.RokSprocket.Features,options:{curve:"cubic-bezier(0.37,0.61,0.59,0.87)",duration:"400ms",data:"slideshow",settings:{animation:"crossfade",autoplay:false,delay:5}},animate:function(b,i,j){var c=b.getElements("[data-"+this.data+"-content]"),h=b.getElements("[data-"+this.data+"-image]"),d=this.getSettings(b),e={content:this.animations.crossfade,image:this.animations[d.animation]||this.animations.crossfade},g={content:c[i],image:h[i]},f={content:c[j],image:h[j]};
if(Browser.ie&&Browser.version<8){c.setStyle("zoom",1);h.setStyle("zoom",1);}Object.each(g,function(m,l){var n=(l=="content")?e[l]:d.animation=="random"?this.getRandom():e[l];
if(l=="content"){c.styles(Object.merge({},n.from,{position:"absolute"}));}if(l=="image"){h.styles(Object.merge({},n.from,{position:"absolute"}));}g[l].styles(Object.merge({},n.to,{"z-index":1}));
var k={"z-index":2,position:"absolute"};if(l=="image"){g[l].styles({position:"relative"});["top","right","bottom","left"].each(function(o){f[l].style[o]="";
},this);if(n=="crossfade"){Object.merge(k,{top:0,left:0});}}f[l].styles(Object.merge({},n.from,k));if(Browser.ie&&Browser.version<9){f[l].set("morph",{link:"cancel",duration:this.options.duration.toInt(),transition:"quad:in:out",onComplete:function(){if(l=="image"){f[l].styles(Object.merge({},n.to,{position:"relative"}));
g[l].styles(Object.merge({},n.from,{position:"absolute"}));}g[l].styles(n.from);f[l].get("morph").removeEvents("onComplete");if(d.autoplay&&d.autoplay.toInt()){this.startTimer(b);
}}.bind(this)}).morph(n.to);if(l=="content"){g[l].set("morph",{link:"cancel",duration:this.options.duration.toInt(),transition:"quad:in:out"}).morph(n.from);
}}else{f[l].moofx(n.to,{duration:this.options.duration,equation:this.options.curve,callback:function(){if(l=="image"){f[l].styles(Object.merge({},n.to,{position:"relative"}));
g[l].styles(Object.merge({},n.from,{position:"absolute"}));}g[l].styles(n.from);if(d.autoplay&&d.autoplay.toInt()){this.startTimer(b);}}.bind(this)});if(l=="content"){g[l].moofx(n.from,{duration:this.options.duration,equation:this.options.curve});
}}},this);}});this.RokSprocket.Slideshow=a;})());