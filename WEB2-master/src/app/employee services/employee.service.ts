import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
interface ExposableEmployee {
	first_name: string;
	last_name: string;
	department_id: number;
	birth_date: any;
}

export interface Employee extends ExposableEmployee {
	id: number;
}
@Injectable({
	providedIn: 'root'
})
export class EmployeeService {
	private _employees: BehaviorSubject<Employee[]> = new BehaviorSubject([]);
	private addedEmployees = 1;
	public employees: Observable<Employee[]> = this._employees.asObservable();
	public positions = [ 'Manager', 'Intern', 'Asistant', 'PR' ];
	private employeeURL = 'http://i875395.hera.fhict.nl/api/384741/employee';
	constructor(private http: HttpClient) {
		this.http.get<Employee[]>(this.employeeURL).subscribe((e) => this._employees.next(e));
	}

	public getEmployees(): Observable<Employee[]> {
		return this.employees;
	}
	public createEmployee(employee: ExposableEmployee) {
		this.http.post(this.employeeURL, employee).subscribe(() => console.log());
	}
	public deleteEmployee(id: number) {
		this.http.delete(this.employeeURL + `?id=${id}`).subscribe();
	}

	public getPositions() {
		return this.positions;
	}

	public updateEmployee(employee: Employee) {
		this.http.put(this.employeeURL + `?id=${employee.id}`, employee).subscribe();
	}

	public async getEmployeeById(id: number) {
		const url = `${this.employeeURL}/${id}`;
		return await this.http.get<Employee>(url);
	}
}
