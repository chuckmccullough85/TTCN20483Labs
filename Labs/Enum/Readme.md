## Overview
In this lab, we will extend the *Temperature* lab by adding an enumeration to represent the various temp scales

| | |
| --------- | --------------------------- |
| Exercise Folder | Enum |
| Builds On | Struct |
| Time to complete | 15 minutes

---

### Steps
1. In *Temperature.cs* before **struct Temperature** define an enum named *TemperatureScale* with 3 values, *CELSIUS*, *FAHRENHEIT*, and *KELVIN*
2. Add another parameter to the *Temperature* constructor so that the scale can be passed.  Make the default value CELSIUS so that we don't break existing code
3. Modify *Program.cs*  so that the various temperature objects can be created with different scales via the constructor




