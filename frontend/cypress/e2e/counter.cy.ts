describe('The Counter Page', () => {
  describe('The Counter', () => {
    beforeEach(() => {
      cy.visit('/counter');
    });

    it('starts with counter at 0', () => {
      cy.get('[data-testid="current-count"]').should('contain.text', '0');
    });

    it('increments the counter when the "+" is clicked', () => {
      cy.get('[data-testid="increment-btn"]').click();
      cy.get('[data-testid="current-count"]').should('contain.text', '1');
    });

    it('decrements the counter when the "-" is clicked', () => {
      cy.get('[data-testid="decrement-btn"]').click();
      cy.get('[data-testid="current-count"]').should('contain.text', '-1');
    });

    it('resets the counter when the "reset" button is clicked', () => {
      cy.get('[data-testid="increment-btn"]').click();
      cy.get('[data-testid="reset-btn"]').click();
      cy.get('[data-testid="current-count"]').should('contain.text', '0');
    });

    it('counts by 5 when the "5" is clicked', () => {
      cy.get('[data-testid="count-by"]').find('[data-testid="5"]').click();
      cy.get('[data-testid="increment-btn"]').click();
      cy.get('[data-testid="current-count"]').should('contain.text', '5');
    });

    it('displays the counter in the masthead', () => {
      cy.get('[data-testid="increment-btn"]').click();
      cy.get('[data-testid="current-display').should(
        'contain.text',
        '(Current is 1)',
      );
    });

    it('maintains the counter state after a refresh', () => {
      cy.get('[data-testid="increment-btn"]').click();
      cy.visit('/counter');
      cy.get('[data-testid="current-count"]').should('contain.text', '1');
    });
  });
});
