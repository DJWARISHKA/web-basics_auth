import { Injectable } from '@angular/core';
import { IAccount, Role } from './account';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpClient: HttpClient) { }

  url: string = "api/admin";

  get(): Observable<IAccount[]> {
    return this.httpClient.get<IAccount[]>(this.url);
  }

  delete(id: number): Observable<{}> {
    return this.httpClient.delete(`${this.url}/${id}`);
  }

  create(email: string, password: string, role: Role): Observable<IAccount> {
    return this.httpClient.post<IAccount>(this.url, { email, password, role });
  }

  changeRole(id: number, role: number): Observable<IAccount> {
    return this.httpClient.put<IAccount>(this.url, { id, role });
  }
}
