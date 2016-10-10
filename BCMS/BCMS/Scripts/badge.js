var scriptTag, badgeDiv;

scriptTag = document.getElementById('kioskfolio-item-badge');

itemUrl = '';

refUser = scriptTag.getAttribute("data-ref");

if (refUser != null) {
  itemUrl = itemUrl + '?ref=' + refUser;
}

badgeDiv = document.createElement('div');
badgeDiv.id = 'kioskfolio-item-badge';
badgeDiv.innerHTML = '<a href="' + itemUrl + '">Purchase</a> <span class="item-badge-sales">639</span>';
scriptTag.parentNode.replaceChild(badgeDiv, scriptTag);

var styleTag = document.createElement("link");
styleTag.setAttribute("href", "css/badge.css");
styleTag.setAttribute("type", "text/css");
styleTag.setAttribute("rel", "stylesheet");

document.getElementsByTagName("head")[0].appendChild(styleTag);