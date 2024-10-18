import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CDBInvestmentRequest } from '../models/cdb-investment-request.model';
import { CDBInvestmentResponse } from '../models/cdb-investment-response.model';

@Injectable({
  providedIn: 'root'
})
export class CDBService {
  private apiUrl = 'http://localhost:5000/api/cdb'; // URL base da API

  constructor(private http: HttpClient) {}

  calculate(request: CDBInvestmentRequest): Observable<CDBInvestmentResponse> {
    return this.http.post<CDBInvestmentResponse>(`${this.apiUrl}/calculate`, request);
  }
}