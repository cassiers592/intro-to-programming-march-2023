describe('The Learning Resources Page', () => {
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

    it('displays the resource name in card header', () => {
      cy.get('[data-testid="resource-list"]')
        .find('[data-testid="card-1"]')
        .find('[data-testid="card-header"]')
        .should('contain.text', 'Google');
    });

    it('displays the resource name in card body', () => {
      cy.get('[data-testid="resource-list"]')
        .find('[data-testid="card-1"]')
        .find('[data-testid="card-body"]')
        .should('contain.text', 'Google');
    });

    it('displays the resource description in card body', () => {
      cy.get('[data-testid="resource-list"]')
        .find('[data-testid="card-1"]')
        .find('[data-testid="card-body"]')
        .should('contain.text', 'Use this for GDD');
    });

    it('displays the resource link in card body', () => {
      cy.get('[data-testid="resource-list"]')
        .find('[data-testid="card-1"]')
        .find('[data-testid="card-body"]')
        .should('contain.text', 'https://www.google.com/');
    });

    it('does not have extra cards', () => {
      cy.get('[data-testid="resource-list"]')
        .find('[data-testid="card-2"]')
        .should('not.exist');
    });
  });
});
