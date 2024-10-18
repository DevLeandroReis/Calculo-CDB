import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-result-item',
    templateUrl: 'result-item.component.html',
})
export class ResultItemComponent {
    @Input() label!: string;
    @Input() value!: string | null;
}
