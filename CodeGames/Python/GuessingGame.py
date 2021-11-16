from random import randint
minimo = int(input('\nQual o número mínimo dentro do jogo: '))
maximo = int(input('Qual o número máximo dentro do jogo: '))
pc = randint(minimo, maximo)
tentativa = 0
user = int(input('\nPensei em um número! Descubra qual é o número entre {} e {}: '.format(minimo, maximo)))
while user != pc:
    tentativa += 1
    if user < pc:
        user = int(input('Um pouco mais... Tente outra vez. Descubra o número entre {} e {}: '.format(minimo, maximo)))
    else:
        user = int(input('Um pouco menos...Tente outra vez. Descubra o número entre {} e {}: '.format(minimo, maximo)))
print('\nParabéns! Você acertou o número {} e só tentou {} vezes! HAHAHAHA'.format(user, tentativa))
