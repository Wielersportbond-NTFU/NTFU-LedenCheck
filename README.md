# NTFU-LedenCheck
 Check if someone is a member of the NTFU by validating the member number against the postal code and/or birthdate. If both are supplied then both must match.
 
 The simple WinForms app is a demo to show how this can be done. This can be implemented in your own project. See the code in "LedenCheck.cs".
 The call to the API is done in "CallNtfuApi.cs". You can use this code to call other NTFU API endpoints as well.

The app makes a GET request to the following url: https://api.ntfu.nl/api/lidcontrole/{membernr}/{postalcode}/{birthdate}

{membernr}: The member number to be validated. Range is 200.000 ~ 1.000.000\
{postalcode}: A Dutch postal code. Use '0' if not available.\
{birthdate}: A birthdate in 'dd-mm-yyyy' format. Use '0' if not available.


# Testing
You can test with the following data.

Membernr:   222222\
Birthdate:  2-2-1902\
Postalcode: 1234AB

Membernr:   999999\
Birthdate:  31-12-2000\
Postalcode: 4321ZY

Membernr:   234567\
Birthdate:  15-6-2020\
Postalcode: 9999XX 


# Examples
Member number with only a postal code: https://api.ntfu.nl/api/lidcontrole/222222/1234AB/0 \
Member number with only a birthdate: https://api.ntfu.nl/api/lidcontrole/222222/0/2-2-1902 \
Member number with postal code and birthdate: https://api.ntfu.nl/api/lidcontrole/222222/1234AB/2-2-1902
