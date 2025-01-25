## Overview
Lets make our collection **foreach** friendly. In this code exercise, you will implement an iterator for the GenericArrayList class.

| | |
| --------- | --------------------------- |
| Exercise Folder | Iterator |
| Builds On | Generics |
| Time to complete | 20 minutes

---

This exercise builds on the Generics lab.  If you have not completed the Generics lab, start with the solution in the [Generics/Solution](../Generics/Solution/GenericsSolution/) folder.

## Instructions

1. Open the `GenericArrayList` class.
2. Add the `IEnumerable<T>` interface to the class definition.
3. Use the *quick fix* tool to implement the interface.
4. Implement the `GetEnumerator` to loop through the items in the array, `yield`ing each item.
5. Run the application to verify success!
