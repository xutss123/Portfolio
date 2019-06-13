import { Injectable } from '@angular/core';
import { EmployeeService } from '../employee services/employee.service';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
interface ExposableDepartment {
	name: string;
}
export interface Department extends ExposableDepartment {
	id: number;
}
const httpOptions = {
	headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
	providedIn: 'root'
})
export class DepartmentService {
	private _departments: BehaviorSubject<Department[]> = new BehaviorSubject([]);
	//private addedDepartments = 0;
	public departments: Observable<Department[]> = this._departments.asObservable();

	constructor(private employeeService: EmployeeService, private http: HttpClient) {
		//this.CreateMockDepartments();
	}

	private departmentsUrl = 'http://i875395.hera.fhict.nl/api/394264/department';

	public getDepartments(): Observable<Department[]> {
		//return this.departments;
		return this.http.get<Department[]>(this.departmentsUrl);
	}

	public createdepartment(department: ExposableDepartment) {
		console.log(department);
		return this.http.post<Department>(this.departmentsUrl, department, httpOptions);

		//	return this._departments.next([
		//		...this._departments.getValue(),
		//		{ ...department, id: ++this.addedDepartments }
		//	]);
	}

	public deletedepartment(Id: Department | number) {
		const id = typeof Id === 'number' ? Id : Id.id;
		const url = `${this.departmentsUrl}?id=${id}`;
		return this.http.delete<Department>(url, httpOptions);
		//return this._departments.next(this._departments.getValue().filter((department) => department.id !== id));
	}

	public getdepartment(id: number): Observable<Department> | null {
		const url = `${this.departmentsUrl}?id=${id}`;
		return this.http.get<Department>(url);
		//const departments = this._departments.getValue().filter((department) => department.id !== id);
		//if (departments.length > 0) {
		//	return departments[0];
		//}
		//return null;
	}
	public getDepartment(name: string): Department | null {
		const departments = this._departments.getValue().filter((department) => department.name === name);
		if (departments.length > 0) {
			return departments[0];
		}
		return null;
	}

	public updatedepartment(updatedDepartment: Department) {
		return this.http.put(this.departmentsUrl, updatedDepartment, httpOptions);

		//	const departments = this._departments.getValue().map((department) => {
		//		if (updatedDepartment.id === department.id) {
		//			return updatedDepartment;
		//		}
		//		return department;
		//	});
		//	return this._departments.next(departments);
	}

	//private CreateMockDepartments() {
	//	const mockTask = ({ name }: { name: string }) =>
	//		this.createdepartment({
	//			name
	//		});

	//	mockTask({ name: 'Students' });
	//	mockTask({ name: 'Cleaners' });
	//	mockTask({ name: 'Teachers' });
	//}
}
