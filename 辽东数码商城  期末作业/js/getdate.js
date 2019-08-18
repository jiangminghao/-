today = new Date();
var day; var date; var hello; var wel;
hour = new Date().getHours()
if (hour < 6) hello = '凌晨好!'
else if (hour < 9) hello = '早上好!'
else if (hour < 12) hello = '上午好!'
else if (hour < 14) hello = '中午好!'
else if (hour < 17) hello = '下午好!'
else if (hour < 19) hello = '傍晚好!'
else if (hour < 22) hello = '晚上好!'
else { hello = '夜里好!' }
if (today.getDay() == 0) day = '星期日'
else if (today.getDay() == 1) day = '星期一'
else if (today.getDay() == 2) day = '星期二'
else if (today.getDay() == 3) day = '星期三'
else if (today.getDay() == 4) day = '星期四'
else if (today.getDay() == 5) day = '星期五'
else if (today.getDay() == 6) day = '星期六'
date = (today.getYear()) + '年' + (today.getMonth() + 1) + '月' + today.getDate() + '日';
document.write(hello);

document.write(date + ' ' + day + ' ');