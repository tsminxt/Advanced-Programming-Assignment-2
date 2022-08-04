# deduct the salary of full-time employee who joined after the year of 1995 by 15%

# Create a python program to calculate new salary of the affected employees 
# and print out the total of the computed salary

import re

lines = []                              # Declare an empty list
with open ('HRMasterlist.txt', 'rt') as file:  # rt = read text
    for line in file:                   # For each line of text,
        lines.append(line)              # add that line to the list.
    for element in lines:               # For each element in the list, print the element
        print(element)  

    SE = element.split()
    Startdate = SE.find((1995))
    print(Startdate)
file.close()