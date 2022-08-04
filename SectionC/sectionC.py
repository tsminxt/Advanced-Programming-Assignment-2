# deduct the salary of full-time employee who joined after the year of 1995 by 15%

# Create a python program to calculate new salary of the affected employees 
# and print out the total of the computed salary



# Date -> split | to 3, / 2 to get  and then to get salary -> split | to 8
#print(list([(int(content.split("|")[3].split("/")[2]))] for content in open("HRMasterlist.txt", "r").readline().split("\n")))

# from ast import Str


# for content in open("./HRMasterlist.txt", "r").read().split("\n"):

#     contents = [(int(content.split("|")[3].split("/")[2]), int(content.split("|")[8]))]

# print(sum([content[1] * 85/100 for content in filter(lambda content: content[0] >= 1995, contents)]))

# print(sum([content[1] * 0.85 for content in filter(lambda employee: employee[0] >= 1995, content)]))

#print(list(int(employee.split("|")[3].split("/")[2])), (str(employee.split("|")[7])), (int(employee.split("|")[8])) for employee in open("./HRMasterlist.txt", "r").read().split("\n"))


# StartDate Year, HireType and Salary
from typing import List

employees = [(int(employee.split("|")[3].split("/")[2]),(str(employee.split("|")[7])), int(employee.split("|")[8])) for employee in open("./HRMasterlist.txt", "r").read().split("\n")]
print(list([employee[2] * 0.85 for employee in filter(lambda employee: employee[0] >= 1995 and employee[1] == 'FullTime', employees)]))
print(sum([employee[2] * 0.85 for employee in filter(lambda employee: employee[0] >= 1995 and employee[1] == 'FullTime', employees)]))

# print(sum([employee[1] * 0.85 for employee in filter(lambda employee: employee[0] >= 1995,[(int(employee.split("|")[3].split("/")[2]),int(employee.split("|")[8])) for employee in open("./HRMasterlist.txt", "r").read().split("\n")])]))
# # print(sum([employee[1] * 0.85 for employee in filter(lambda employee: employee[0] >= 1995, employees)]))


# ORIGINAL
# employees = [(int(employee.split("|")[3].split("/")[2]),int(employee.split("|")[8])) for employee in open("./HRMasterlist.txt", "r").read().split("\n")]
# print(sum([employee[1] * 0.85 for employee in filter(lambda employee: employee[0] >= 1995, employees)]))

#print(list((int(employee.split("|")[3].split("/")[2]),int(employee.split("|")[8])) for employee in open("./HRMasterlist.txt", "r").read().split("\n")))
#print(list([employee[1] * 0.85 for employee in filter(lambda employee: employee[0] >= 1995, employees)]))

#New One
# employees = [(int(employee.split("|")[3].split("/")[2]),(str(employee.split("|")[7]), int(employee.split("|")[8]))) for employee in open("./HRMasterlist.txt", "r").read().split("\n")]
# print(list([employee[1] * 0.85 for employee in filter(lambda employee: employee[0] >= 1995, employees)]))