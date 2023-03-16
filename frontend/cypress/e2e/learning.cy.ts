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

  describe('The List Page', () => {
    beforeEach(() => {
      cy.intercept(
        {
          method: 'GET',
          url: 'http://localhost:1340/learning-resources',
        },
        {
          statusCode: 200,
          body: {
            data: [
              {
                id: '1',
                name: 'Google',
                description: 'Use this for GDD',
                link: 'https://www.google.com/',
              },
            ],
          },
        },
      );
      cy.visit('/learning/list');
    });

    it('had the list displayed', () => {
      cy.get('[data-testid="resource-list"]').should('exist');
    });

    it('displays the resource name', () => {
      cy.get('[data-testid="resource-list"]').should('contain', 'Google');
    });
  });
});
