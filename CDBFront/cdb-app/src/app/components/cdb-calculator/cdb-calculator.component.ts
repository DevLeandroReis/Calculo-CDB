import { Component } from '@angular/core';
import { CDBService } from '../../services/cdb.service';
import { CDBInvestmentRequest } from '../../models/cdb-investment-request.model';
import { CDBInvestmentResponse } from '../../models/cdb-investment-response.model';
import { AlertService } from '../../services/alert.service';

@Component({
  selector: 'app-cdb-calculator',
  templateUrl: './cdb-calculator.component.html',
  styleUrls: ['./cdb-calculator.component.scss'],
})
export class CdbCalculatorComponent {
  request: CDBInvestmentRequest = { investedAmount: null, termInMonths: null };
  response: CDBInvestmentResponse | null = null;

  constructor(
    private cdbService: CDBService,
    private alertService: AlertService
  ) {}

  calculate() {
    this.response = null;

    this.cdbService.calculate(this.request).subscribe({
      next: (res) => {
        this.response = res;
        this.alertService.showSuccess('Calculated with success.');
      },
      error: (err) => {
        if (err.status === 400 && err.error.errors) {
          const warnings = err.error.errors.split('|').map((msg: string) => msg.trim());
          this.alertService.showWarnings(warnings);
        } else {
          this.alertService.showError('An error occurred during the calculation.');
        }
        console.error(err);
      },
    });
  }
}