# KryptoLab4
## Part 1
<b>Passwords generating:</b><br>
Lists of 100 and 1M most popular passwords were found using Google:<br>
100 - https://www.ianoffers.com/top-100-passwords-of-2018/<br>
1M - https://github.com/danielmiessler/SecLists/blob/master/Passwords/Common-Credentials/10-million-password-list-top-1000000.txt<br>
Random passwords were composed from 0..9, a..z and A..Z (each password length = 8).<br>
"Human-like" passwords were composed from 3000 most common english words and symbols "0123456789!@#$%^&*-_". In half of cases some letters were replaced with corresponding numbers.<br>
List of most common english words - https://www.ef.com/wwen/english-resources/english-vocabulary/top-3000-words/<br>
<br>
Percentage of generated passwords:<br>
Top 100 - 5%<br>
Top 1M - 89%<br>
Random - 5%<br>
"Human-like" - 1%<br>
<br>
After user enters count of passwords to generate, for every needed password random number from 1..100 is generated. It defines the type of password to generate. Then random password is chosen from list of paswords of given type.<br>
Generated passwords are written to Out.txt (not present in this repository because of whole idea of this task).<br>
<br>
<b>Passwords hashing:</b><br>
In the final version MD5, SHA1 + salt and Blake3 were used. Also Argon2i and BCrypt were tried but it was taking too much time for them to generate hashes (what a surprise))).<br>
Realizations of these algorithms were taken from some .NET packages.<br>
Results of hashing were saved to corresponding .csv files (even some resuls for Argon2i and BCrypt are there).<br>
![programWorkScreen.png](https://github.com/YaJProgrammist/KryptoLab4/blob/main/Screenshots/programWorkScreen.png?raw=true)