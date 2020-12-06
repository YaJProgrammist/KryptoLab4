# KryptoLab4
## Part 1
<b>Passwords generating:</b>
Lists of 100 and 1M most popular passwords were found using Google:
100 - https://www.ianoffers.com/top-100-passwords-of-2018/
1M - https://github.com/danielmiessler/SecLists/blob/master/Passwords/Common-Credentials/10-million-password-list-top-1000000.txt
Random passwords were generated using random.org passwords generator (https://www.random.org/passwords/).
"Human-like" passwords were written manually.

Percentage of generated passwords:
Top 100 - 5%
Top 1M - 89%
Random - 5%
"Human-like" - 1%

After user enters count of passwords to generate, for every needed password random number from 1..100 is generated. It defines the type of password to generate. Then random password is chosen from list of paswords of given type.
Generated passwords are written to Out.txt (not present in this repository because of whole idea of this task).
