import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-calculation-result',
    templateUrl: './calculation-result.component.html',
    styleUrls: ['../cdb-calculator.component.scss']
})
export class CalculationResultComponent {
    @Input() response: any;
}