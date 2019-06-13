import { Component, OnInit, Input } from '@angular/core';
import { EmployeeService } from '../employee services/employee.service';
import { Employee } from '../employee services/employee.service';
import { DepartmentService, Department } from '../services/department.service';

@Component({
	selector: 'app-employees',
	templateUrl: './employees.component.html',
	styleUrls: [ './employees.component.css' ]
})
export class EmployeesComponent implements OnInit {
	constructor(private employeeService: EmployeeService, private departmentService: DepartmentService) {}

	public employees = [];
	public positions = [];
	public departments = [];
	public selectedEmployee: Employee;
	public Dep: Department;

	@Input() Employee: Employee;
	ngOnInit() {
		this.employeeService.getEmployees().subscribe((employees) => {
			console.log(employees);
			this.employees = employees;
		});

		this.departmentService.getDepartments().subscribe((departments) => {
			this.departments = departments;
		});

		this.positions = this.employeeService.getPositions();
	}
	onSelect(employee: Employee): void {
		this.selectedEmployee = employee;
	}
	public deleteEmployee(id: number) {
		this.employeeService.deleteEmployee(Number(id));
	}
	public getName(id: number): String {
		this.departmentService.getdepartment(id).subscribe((dep) => {
			this.Dep = dep;
		});
		return this.Dep.name;
	}
	public getEmployee(id: number) {
		return this.employeeService.getEmployeeById(id);
	}
	public Add(first_name: string, last_name: string, department_id: number) {
		this.employeeService.createEmployee({
			first_name,
			last_name,
			department_id: 193,
			birth_date: null
		});
	}
	save(): void {
		this.employeeService.updateEmployee(this.selectedEmployee);
	}
}
