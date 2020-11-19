import { ArticlesAppPage } from './app.po';

describe('articles-app App', function() {
  let page: ArticlesAppPage;

  beforeEach(() => {
    page = new ArticlesAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
