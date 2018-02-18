import { ListClientsModule } from './list-clients.module';

describe('ListClientsModule', () => {
    let listClientsModule: ListClientsModule;

  beforeEach(() => {
      listClientsModule = new ListClientsModule();
  });

  it('should create an instance', () => {
      expect(listClientsModule).toBeTruthy();
  });
});
