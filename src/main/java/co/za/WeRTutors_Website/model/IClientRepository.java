package co.za.WeRTutors_Website.model;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface IClientRepository extends MongoRepository<Client_Parent, String> {
    // You can define custom query methods here if necessary
    Client_Parent findByEmail(String userEmail);

}
