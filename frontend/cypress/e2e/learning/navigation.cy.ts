describe('The Learning Resources Page', () => {
  describe('The Learning Navigation', () => {
    beforeEach(() => {
      cy.visit('/learning');
    });

    it('navigates to the overview when "Overview" is clicked', () => {
      cy.get('[data-testid="overview-btn"]').click();
      cy.url().should('contain', '/learning/overview');
    });

    it('navigates to the list when "List" is clicked', () => {
      cy.get('[data-testid="list-btn"]').click();
      cy.url().should('contain', '/learning/list');
    });

    it('navigates to the new when "Add a Resource" is clicked', () => {
      cy.get('[data-testid="new-btn"]').click();
      cy.url().should('contain', '/learning/new');
    });
  });
});
