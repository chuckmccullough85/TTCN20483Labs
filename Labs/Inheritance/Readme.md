## Overview
Our application needs to support a variety of employee types

| | |
| --------- | --------------------------- |
| Exercise Folder | Inheritance |
| Builds On | Lambda |
| Time to complete | 30 minutes| 

---

> **Note** This lab is a continuation of the Lambda lab.  If you have not completed the Lambda lab, use the [Lambda Solution](../Lambdas/Solution/) as the starting point for this lab.


### Lab Overview

- Define new classes
    - *Contractor* - contractors make a fixed rate X 50 hours
    - *Intern* - interns are always paid a stipend of $50
    - *HumanResource* - the base class for contractors, interns, and employees
- Define tests for the new classes
- Update Company to contain *Human Resource* objects

## Steps
1. Create new classes, *HumanResource, Contractor, & Intern*
1. Change *Employee* to inherit from *HumanResource*
1. Pull up from *Employee* to *HumanResource* the common fields and properties
    - Name
    - Home and work addresses
    - YtdEarnings
1. Define *Pay* as a abstract method in *HumanResource*
1. Define a constructor in *HumanResource* taking name as parameter
1. Fix up Employee class
1. Change *Contractor* and *Intern* to inherit from *HumanResource*
1. Re-run unit tests - company and employee tests should still succeed
1. Create new classes *ContractorTest & InternTest*
    - implement tests to specify *Pay* results
    - verify new tests fail
    - implement *Intern & Contractor* so that tests pass
1. Update *Company* to contain *HumanResource* objects