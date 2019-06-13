import { Component, OnInit, Input } from '@angular/core';
import { DepartmentService } from '../services/department.service';
import { Department } from '../services/department.service';
import { Employee } from './../employee services/employee.service';
import { EmployeeService } from './../employee services/employee.service';
@Component({
	selector: 'app-departments',
	templateUrl: './departments.component.html',
	styleUrls: [ './departments.component.css' ]
})
export class DepartmentComponent implements OnInit {
	@Input() department: Department;

	public departments;
	public selectedDepartment;
	public employees: Array<Employee>;
	constructor(private departmentService: DepartmentService, private employeeService: EmployeeService) {}

	ngOnInit() {
		this.departmentService.getDepartments().subscribe((departments) => {
			this.departments = departments;
		});

		this.employeeService.getEmployees().subscribe((e) => {
			this.employees = e;
		});
	}

	public changeid() {
		this.departmentService.updatedepartment({ ...this.department });
	}

	public changename(name: string) {
		this.departmentService.updatedepartment({ ...this.department, name });
	}

	public deleteDepartment(id: number) {
		this.departmentService.deletedepartment(Number(id));
	}
	public addDepartment(name: string) {
		this.departmentService.createdepartment({ name });
	}

	public getEmployees(id: number) {
		return this.employees.filter((e) => e.department_id === id);
	}
	public onSelectDep(department: Department): void {
		this.selectedDepartment = department;
	}
}
