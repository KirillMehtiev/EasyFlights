export interface IInternalNavigation {
    onNextStep?: KnockoutSubscribable<number>;
    onPreviousStep?: KnockoutSubscribable<number>;
}