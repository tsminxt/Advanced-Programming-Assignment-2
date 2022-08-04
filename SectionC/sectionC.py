employees = [(int(affected_employee.split("|")[3].split("/")[2]),(str(affected_employee.split("|")[7])), int(affected_employee.split("|")[8])) for affected_employee in open("./HRMasterlist.txt", "r").read().split("\n")]
print(sum([affected_employee[2] * 0.85 for affected_employee in filter(lambda affected_employee: affected_employee[0] >= 1995 and affected_employee[1] == 'FullTime', employees)]))
