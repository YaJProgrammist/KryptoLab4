# KryptoLab4
## Part 1
<b>Passwords generating:</b><br>
Lists of 100 and 1M most popular passwords were found using Google:<br>
100 - https://www.ianoffers.com/top-100-passwords-of-2018/<br>
1M - https://github.com/danielmiessler/SecLists/blob/master/Passwords/Common-Credentials/10-million-password-list-top-1000000.txt<br>
Random passwords were generated using random.org passwords generator (https://www.random.org/passwords/).<br>
"Human-like" passwords were written manually.<br>
<br>
Percentage of generated passwords:<br>
Top 100 - 5%<br>
Top 1M - 89%<br>
Random - 5%<br>
"Human-like" - 1%<br>
<br>
After user enters count of passwords to generate, for every needed password random number from 1..100 is generated. It defines the type of password to generate.<br> Then random password is chosen from list of paswords of given type.<br>
Generated passwords are written to Out.txt (not present in this repository because of whole idea of this task).<br>
