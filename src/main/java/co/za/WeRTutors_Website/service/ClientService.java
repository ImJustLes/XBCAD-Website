package co.za.WeRTutors_Website.service;

import co.za.WeRTutors_Website.model.Client_Parent;
import co.za.WeRTutors_Website.model.Security;
import co.za.WeRTutors_Website.repository.IClientRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ClientService {

    @Autowired
    private IClientRepository clientRepository;
    @Autowired
    private Security encryptionService;

    public void SaveClient(Client_Parent client) {
        // Encrypt the password before saving
        client.setPassword(encryptionService.encryptPassword(client.getPassword()));
        clientRepository.save(client);
    }

    public void LoginClient(Client_Parent client)
    {
        client.setEmail(client.getEmail());
        clientRepository.findByEmail(client.getEmail());
    }

}
