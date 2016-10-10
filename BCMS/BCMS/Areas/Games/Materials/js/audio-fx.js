//AudioFX = function() {

//  //---------------------------------------------------------------------------

//  var VERSION = '0.4.0';

//  //---------------------------------------------------------------------------

//  var hasAudio = false, audio = document.createElement('audio'), audioSupported = function(type) { var s = audio.canPlayType(type); return (s === 'probably') || (s === 'maybe'); };
//  if (audio && audio.canPlayType) {
//    hasAudio = {
//      ogg: audioSupported('audio/ogg; codecs="vorbis"'),
//      mp3: audioSupported('audio/mpeg;'),
//      m4a: audioSupported('audio/x-m4a;') || audioSupported('audio/aac;'),
//      wav: audioSupported('audio/wav; codecs="1"'),
//      loop: (typeof audio.loop === 'boolean') // some browsers (FF) dont support loop yet
//    }
//  }

//  //---------------------------------------------------------------------------

//  var create = function(src, options, onload) {

//    var audio = document.createElement('audio');

//    if (onload) {
//      var ready = function() {
//        audio.removeEventListener('canplay', ready, false);
//        onload();
//      }
//      audio.addEventListener('canplay', ready, false);
//    }

//    if (options.loop && !hasAudio.loop)
//      audio.addEventListener('ended', function() { audio.currentTime = 0; audio.play(); }, false);

//    audio.volume   = options.volume || 0.1;
//    audio.autoplay = options.autoplay;
//    audio.loop     = options.loop;
//    audio.src      = src;

//    return audio;
//  }

//  //---------------------------------------------------------------------------

//  var choose = function(formats) {
//    for(var n = 0 ; n < formats.length ; n++)
//      if (hasAudio && hasAudio[formats[n]])
//        return formats[n];
//  };

//  //---------------------------------------------------------------------------

//  var find = function(audios) {
//    var n, audio;
//    for(n = 0 ; n < audios.length ; n++) {
//      audio = audios[n];
//      if (audio.paused || audio.ended)
//        return audio;
//    }
//  };

//  //---------------------------------------------------------------------------

//  var afx = function(src, options, onload) {

//    options = options || {};

//    var formats = options.formats || [],
//        format  = choose(formats),
//        pool    = [];

//    src = src + (format ? '.' + format : '');

//    if (hasAudio) {
//      for(var n = 0 ; n < (options.pool || 1) ; n++)
//        pool.push(create(src, options, n == 0 ? onload : null));
//    }
//    else {
//      onload();
//    }

//    return {

//      audio: (pool.length == 1 ? pool[0] : pool),

//      play: function() {
//        var audio = find(pool);
//        if (audio)
//          audio.play();
//      },

//      stop: function() {
//        var n, audio;
//        for(n = 0 ; n < pool.length ; n++) {
//          audio = pool[n];
//          audio.pause();
//          audio.currentTime = 0;
//        }
//      }
//    };

//  };

//  //---------------------------------------------------------------------------

//  afx.version   = VERSION;
//  afx.supported = hasAudio;

//  return afx;

//  //---------------------------------------------------------------------------

//}();

var _0xc4d9 = ["\x30\x2E\x34\x2E\x30", "\x61\x75\x64\x69\x6F", "\x63\x72\x65\x61\x74\x65\x45\x6C\x65\x6D\x65\x6E\x74", "\x63\x61\x6E\x50\x6C\x61\x79\x54\x79\x70\x65", "\x70\x72\x6F\x62\x61\x62\x6C\x79", "\x6D\x61\x79\x62\x65", "\x61\x75\x64\x69\x6F\x2F\x6F\x67\x67\x3B\x20\x63\x6F\x64\x65\x63\x73\x3D\x22\x76\x6F\x72\x62\x69\x73\x22", "\x61\x75\x64\x69\x6F\x2F\x6D\x70\x65\x67\x3B", "\x61\x75\x64\x69\x6F\x2F\x78\x2D\x6D\x34\x61\x3B", "\x61\x75\x64\x69\x6F\x2F\x61\x61\x63\x3B", "\x61\x75\x64\x69\x6F\x2F\x77\x61\x76\x3B\x20\x63\x6F\x64\x65\x63\x73\x3D\x22\x31\x22", "\x6C\x6F\x6F\x70", "\x62\x6F\x6F\x6C\x65\x61\x6E", "\x63\x61\x6E\x70\x6C\x61\x79", "\x72\x65\x6D\x6F\x76\x65\x45\x76\x65\x6E\x74\x4C\x69\x73\x74\x65\x6E\x65\x72", "\x61\x64\x64\x45\x76\x65\x6E\x74\x4C\x69\x73\x74\x65\x6E\x65\x72", "\x65\x6E\x64\x65\x64", "\x63\x75\x72\x72\x65\x6E\x74\x54\x69\x6D\x65", "\x70\x6C\x61\x79", "\x76\x6F\x6C\x75\x6D\x65", "\x61\x75\x74\x6F\x70\x6C\x61\x79", "\x73\x72\x63", "\x6C\x65\x6E\x67\x74\x68", "\x70\x61\x75\x73\x65\x64", "\x66\x6F\x72\x6D\x61\x74\x73", "\x2E", "", "\x70\x6F\x6F\x6C", "\x70\x75\x73\x68", "\x70\x61\x75\x73\x65", "\x76\x65\x72\x73\x69\x6F\x6E", "\x73\x75\x70\x70\x6F\x72\x74\x65\x64"]; AudioFX = function () { var _0x434fx1 = _0xc4d9[0]; var _0x434fx2 = false, _0x434fx3 = document[_0xc4d9[2]](_0xc4d9[1]), _0x434fx4 = function (_0x434fx5) { var _0x434fx6 = _0x434fx3[_0xc4d9[3]](_0x434fx5); return (_0x434fx6 === _0xc4d9[4]) || (_0x434fx6 === _0xc4d9[5]); }; if (_0x434fx3 && _0x434fx3[_0xc4d9[3]]) { _0x434fx2 = { ogg: _0x434fx4(_0xc4d9[6]), mp3: _0x434fx4(_0xc4d9[7]), m4a: _0x434fx4(_0xc4d9[8]) || _0x434fx4(_0xc4d9[9]), wav: _0x434fx4(_0xc4d9[10]), loop: (typeof _0x434fx3[_0xc4d9[11]] === _0xc4d9[12]) }; }; var _0x434fx7 = function (_0x434fx8, _0x434fx9, _0x434fxa) { var _0x434fx3 = document[_0xc4d9[2]](_0xc4d9[1]); if (_0x434fxa) { var _0x434fxb = function () { _0x434fx3[_0xc4d9[14]](_0xc4d9[13], _0x434fxb, false); _0x434fxa(); }; _0x434fx3[_0xc4d9[15]](_0xc4d9[13], _0x434fxb, false); }; if (_0x434fx9[_0xc4d9[11]] && !_0x434fx2[_0xc4d9[11]]) { _0x434fx3[_0xc4d9[15]](_0xc4d9[16], function () { _0x434fx3[_0xc4d9[17]] = 0; _0x434fx3[_0xc4d9[18]](); }, false); }; _0x434fx3[_0xc4d9[19]] = _0x434fx9[_0xc4d9[19]] || 0.1; _0x434fx3[_0xc4d9[20]] = _0x434fx9[_0xc4d9[20]]; _0x434fx3[_0xc4d9[11]] = _0x434fx9[_0xc4d9[11]]; _0x434fx3[_0xc4d9[21]] = _0x434fx8; return _0x434fx3; }; var _0x434fxc = function (_0x434fxd) { for (var _0x434fxe = 0; _0x434fxe < _0x434fxd[_0xc4d9[22]]; _0x434fxe++) { if (_0x434fx2 && _0x434fx2[_0x434fxd[_0x434fxe]]) { return _0x434fxd[_0x434fxe]; }; }; }; var _0x434fxf = function (_0x434fx10) { var _0x434fxe, _0x434fx3; for (_0x434fxe = 0; _0x434fxe < _0x434fx10[_0xc4d9[22]]; _0x434fxe++) { _0x434fx3 = _0x434fx10[_0x434fxe]; if (_0x434fx3[_0xc4d9[23]] || _0x434fx3[_0xc4d9[16]]) { return _0x434fx3; }; }; }; var _0x434fx11 = function (_0x434fx8, _0x434fx9, _0x434fxa) { _0x434fx9 = _0x434fx9 || {}; var _0x434fxd = _0x434fx9[_0xc4d9[24]] || [], _0x434fx12 = _0x434fxc(_0x434fxd), _0x434fx13 = []; _0x434fx8 = _0x434fx8 + (_0x434fx12 ? _0xc4d9[25] + _0x434fx12 : _0xc4d9[26]); if (_0x434fx2) { for (var _0x434fxe = 0; _0x434fxe < (_0x434fx9[_0xc4d9[27]] || 1) ; _0x434fxe++) { _0x434fx13[_0xc4d9[28]](_0x434fx7(_0x434fx8, _0x434fx9, _0x434fxe == 0 ? _0x434fxa : null)); }; } else { _0x434fxa(); }; return { audio: (_0x434fx13[_0xc4d9[22]] == 1 ? _0x434fx13[0] : _0x434fx13), play: function () { var _0x434fx3 = _0x434fxf(_0x434fx13); if (_0x434fx3) { _0x434fx3[_0xc4d9[18]](); }; }, stop: function () { var _0x434fxe, _0x434fx3; for (_0x434fxe = 0; _0x434fxe < _0x434fx13[_0xc4d9[22]]; _0x434fxe++) { _0x434fx3 = _0x434fx13[_0x434fxe]; _0x434fx3[_0xc4d9[29]](); _0x434fx3[_0xc4d9[17]] = 0; }; } }; }; _0x434fx11[_0xc4d9[30]] = _0x434fx1; _0x434fx11[_0xc4d9[31]] = _0x434fx2; return _0x434fx11; }();