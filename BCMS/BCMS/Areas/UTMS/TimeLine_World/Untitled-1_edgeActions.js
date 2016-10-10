/***********************
* Adobe Edge Animate Composition Actions
*
* Edit this file with caution, being careful to preserve 
* function signatures and comments starting with 'Edge' to maintain the 
* ability to interact with these actions from within Adobe Edge Animate
*
***********************/
(function($, Edge, compId){
var Composition = Edge.Composition, Symbol = Edge.Symbol; // aliases for commonly used Edge classes

   //Edge symbol: 'stage'
   (function(symbolName) {
      
      
      Symbol.bindElementAction(compId, symbolName, "${international}", "click", function(sym, e) {
         
         
         for(var x = 22 ; x <= 43 ;x++)
         sym.$("Group"+x).show(1500);

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${Arabic}", "click", function(sym, e) {
         // insert code for mouse click here
         // Hide an element 
         var y = ["Group43","Group42","Group41","Group40","Group39","Group37","Group28","Group38","Group36","Group35","Group34","Group26","Group22"];
         for(var i = 0; i < y.length;i++)
         {
         if(i > 6){
         sym.$(y[i]).show(1500);
         continue;
         }
         sym.$(y[i]).hide(1500);
         }
         

      });
      //Edge binding end

      Symbol.bindElementAction(compId, symbolName, "${Gulf}", "click", function(sym, e) {
          var y = ["Group43","Group42","Group41","Group40","Group39","Group38","Group37","Group36","Group35","Group34","Group28","Group26","Group22"];
                  for(var i = 0; i < y.length;i++)
                  sym.$(y[i]).hide(1500);

      });
      //Edge binding end

   })("stage");
   //Edge symbol end:'stage'

   //=========================================================
   
   //Edge symbol: 'NYSE'
   (function(symbolName) {   
   
   })("NYSE");
   //Edge symbol end:'NYSE'

   //=========================================================
   
   //Edge symbol: 'international'
   (function(symbolName) {   
   
   })("international");
   //Edge symbol end:'international'

   //=========================================================
   
   //Edge symbol: 'Arabic'
   (function(symbolName) {   
   
   })("Arabic");
   //Edge symbol end:'Arabic'

   //=========================================================
   
   //Edge symbol: 'Gulf'
   (function(symbolName) {   
   
   })("Gulf");
   //Edge symbol end:'Gulf'

})(window.jQuery || AdobeEdge.$, AdobeEdge, "EDGE-431897187");