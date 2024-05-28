import { Component, ContentChildren, QueryList, AfterContentInit, TemplateRef, OnInit, Input } from '@angular/core';
import { CdkStep, CdkStepper } from '@angular/cdk/stepper';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.scss'],
  providers: [{ provide: CdkStepper, useExisting: StepperComponent }]
})
export class StepperComponent extends CdkStepper implements OnInit,AfterContentInit {
  @Input() linearModeSelected: boolean= true;

  ngOnInit(): void {
    this.linear= this.linearModeSelected;
  }

  @ContentChildren(CdkStep, { read: CdkStep }) override steps!: QueryList<CdkStep>;

  currentStep = 0;

  setStep(index: number) {
    this.currentStep = index;
  }

  get currentStepTemplate(): TemplateRef<any> | null {
    return this.steps.toArray()[this.currentStep]?.content;
  }

  override ngAfterContentInit() {
    if (this.steps.length) {
      this.currentStep = 0;
    }
  }
}
